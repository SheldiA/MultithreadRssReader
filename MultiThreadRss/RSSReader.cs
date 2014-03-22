using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace MultiThreadRss
{
    class RSSReader
    {
        private RssChannel rssChannel;
        private List<RssItem> articles;
        private string sourceName;
        private List<string> filters;

        public RSSReader(string sourceName,List<string> filters)
        {
            rssChannel = new RssChannel();
            this.sourceName = sourceName;
            articles = new List<RssItem>();
            this.filters = filters;
        }

        public List<RssItem> GetItems()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlTextReader xmlTextReader = new XmlTextReader(sourceName);
                doc.Load(xmlTextReader);
                xmlTextReader.Close();
                
                XmlNode root = doc.DocumentElement;
                
                XmlNodeList nodeList = root.ChildNodes;
                foreach(XmlNode channel in nodeList)
                {
                    foreach(XmlNode channel_item in channel)
                    {
                        switch(channel_item.Name)
                        {
                            case "title":
                                rssChannel.title = channel_item.InnerText;
                                break;
                            case "description":
                                rssChannel.description = channel_item.InnerText;
                                break;
                            case "link":
                                rssChannel.link = channel_item.InnerText;
                                break;
                            case "copyright":
                                rssChannel.copyright = channel_item.InnerText;
                                break;

                            case "item":
                                XmlNodeList itemsList = channel_item.ChildNodes;
                                RssItem currItem = new RssItem();
                                foreach(XmlNode item in itemsList)
                                    switch(item.Name)
                                    {
                                        case "title":
                                            currItem.title = item.InnerText;
                                            break;
                                        case "link":
                                            currItem.link = item.InnerText;
                                            break;
                                        case "description":
                                            currItem.description = item.InnerText;
                                            break;
                                        case "pubDate":
                                            currItem.pubData = item.InnerText;
                                            break;
                                    }
                                if(CheckFiltering(currItem))
                                    articles.Add(currItem);
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                articles = null;
            }

            return articles;
        }

        private bool CheckFiltering(RssItem item)
        {
            bool result = true;

            foreach(string str in filters)
                if(!(item.title.Contains(str) || item.pubData.Contains(str)))
                {
                    result = false;
                    break;
                }

            return result;
        }

    }

    

}
