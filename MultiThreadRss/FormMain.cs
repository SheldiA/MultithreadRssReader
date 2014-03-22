using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Helpers;
using System.Threading;

namespace MultiThreadRss
{
    public partial class FormMain : Form
    {
        private List<RssItem> allArticles;
        private List<string> keyWords;
        private int numbComputingSources = 0;
        private int numbSendingEmails = 0;
        Object lockAllArticles;
        Object lockNumbMails;

        public FormMain()
        {
            InitializeComponent();
            dgv_rssSources.Rows.Add("http://tech.onliner.by/feed");
            dgv_rssSources.Rows.Add("http://www.vedomosti.ru/rss/themes/finance.xml");
            lockAllArticles = new Object();
            lockNumbMails = new Object();
        }

        private void GetRssInform(object sourcePath)
        {
            string source = sourcePath as string;
            RSSReader currReader = new RSSReader(source, keyWords);
            List<RssItem> addingRss = currReader.GetItems();
            lock (lockAllArticles)
            {
                if (addingRss != null)
                {
                    allArticles.AddRange(addingRss);
                    ++numbComputingSources;
                }
            }
        }

        private void SendMail(object email)
        {
            string toEmail = email as string;
            WebMail.SmtpServer = "smtp.mail.ru";
            WebMail.SmtpPort = 25;
            WebMail.EnableSsl = true;
            WebMail.UserName = "anadena@mail.ru";
            WebMail.Password = "ann418";
            WebMail.From = "anadena@mail.ru";
            List<string> list = new List<string>();
            string s = Application.ExecutablePath;
            list.Add("D:\\MyProjects\\ProjectsC#\\MultiThreadRss\\MultiThreadRss\\bin\\Debug\\last_articles.html");
            WebMail.Send(toEmail, "RssList", "", null,null, list);
            lock (lockNumbMails)
                ++numbSendingEmails;
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            

            allArticles = new List<RssItem>();
            keyWords = new List<string>();

            for(int i = 0; i < dgv_keyWords.Rows.Count - 1; ++i)
            {
                keyWords.Add(dgv_keyWords.Rows[i].Cells[0].Value.ToString());
            }


            int numbSources = dgv_rssSources.Rows.Count - 1;
            for(int i = 0; i < numbSources; ++i)
            {
                string source = dgv_rssSources.Rows[i].Cells[0].Value.ToString();
                Thread thread = new Thread(GetRssInform);
                thread.Start(source);
            }


            while(numbComputingSources != numbSources)
            {
                Thread.Sleep(100);
            }

            HtmlGenerator htmlGenerator = new HtmlGenerator("");
            htmlGenerator.GenerateHtml(allArticles);

            int numbMails = dgv_emails.Rows.Count - 1;
            for (int i = 0; i < numbMails; ++i )
            {
                string email = dgv_emails.Rows[i].Cells[0].Value.ToString();
                Thread thread = new Thread(SendMail);
                thread.Start(email);
            }

            while (numbSendingEmails != numbMails)
                Thread.Sleep(100);
            MessageBox.Show("Success");
        }

    }
}
