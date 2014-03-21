using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiThreadRss
{
    class HtmlGenerator
    {
        private string outcomingFilePath;

        public HtmlGenerator(string path)
        {
            outcomingFilePath = path;
        }

        public bool GenerateHtml(List<RssItem> articles)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("last_articles.html"))
                {
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">");
   
                    writer.WriteLine("<style type='text/css'>");
                    writer.WriteLine("A{color:#483D8B; text-decoration:none; font:Verdana;}");
                    writer.WriteLine("pre{font-family:courier;color:#000000;");
                    writer.WriteLine("background-color:#dfe2e5;padding-top:5pt;padding-left:5pt;");
                    writer.WriteLine("padding-bottom:5pt;border-top:1pt solid #87A5C3;");
                    writer.WriteLine("border-bottom:1pt solid #87A5C3;border-left:1pt solid #87A5C3;");
                    writer.WriteLine("border-right : 1pt solid #87A5C3;	text-align : left;}");
                    writer.WriteLine("</style>");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body>");

                    writer.WriteLine("<table width=\"80%\" align=\"center\" border=1>");
                    foreach (RssItem article in articles)
                    {
                        writer.WriteLine("<tr>");
                        writer.WriteLine("<td>");
                        writer.WriteLine("<br>  <a href=\"" + article.link + "\"><b>" + article.title + "</b></a>");
                        writer.WriteLine("(" + article.pubData + ")<br><br>");
                        writer.WriteLine("<table width=\"95%\" align=\"center\" border=0>");
                        writer.WriteLine("<tr><td>");
                        writer.WriteLine(article.description);
                        writer.WriteLine("</td></tr></table>");
                        writer.WriteLine("<br>  <a href=" + article.link + "\">");
                        writer.WriteLine("<font size=\"1\">читать дальше</font></a><br><br>");
                        writer.WriteLine("</td>");
                        writer.WriteLine("</tr>");
                    }
                    writer.WriteLine("</table><br>");

                    writer.WriteLine("</font>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
