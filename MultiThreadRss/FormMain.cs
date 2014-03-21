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

namespace MultiThreadRss
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            dgv_rssSources.Rows.Add("http://tech.onliner.by/feed");
            dgv_rssSources.Rows.Add("http://www.vedomosti.ru/rss/themes/finance.xml");
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            /*WebMail.SmtpServer = "smtp.mail.ru";
            WebMail.SmtpPort = 25;
            WebMail.EnableSsl = true;
            WebMail.UserName = "anadena@mail.ru";
            WebMail.Password = "ann418";
            WebMail.From = "anadena@mail.ru";
            List<string> list = new List<string>();
            string s = Application.ExecutablePath;
            list.Add("D:\\MyProjects\\ProjectsC#\\MultiThreadRss\\MultiThreadRss\\bin\\Debug\\last_articles.html");
            WebMail.Send("banadena@gmail.com", "hoh", "First mail", null,null, list);*/
            List<RssItem> allArticles = new List<RssItem>();
            for(int i = 0; i < dgv_rssSources.Rows.Count - 1; ++i)
            {
                string source = dgv_rssSources.Rows[i].Cells[0].Value.ToString();
                RSSReader currReader = new RSSReader(source);
                if (source != "")
                    allArticles.AddRange(currReader.GetItems());
            }
            HtmlGenerator htmlGenerator = new HtmlGenerator("");
            htmlGenerator.GenerateHtml(allArticles);
            MessageBox.Show("Success");
        }

    }
}
