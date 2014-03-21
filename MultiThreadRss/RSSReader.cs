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
        private ImageOfChanel imageChanel;
        private RssItem[] articles;
        private string sourceName;
        public RSSReader(string sourceName)
        {
            rssChannel = new RssChannel();
            imageChanel = new ImageOfChanel();
            this.sourceName = sourceName;
        }

        public RssItem[] GetItems()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlTextReader xmlTextReader = new XmlTextReader(sourceName);
                doc.Load(xmlTextReader);
                xmlTextReader.Close();
                
                XmlNode root = doc.DocumentElement;
                articles = new RssItem[root.SelectNodes("channel/item").Count];
                XmlNodeList nodeList = root.ChildNodes;
                int count = 0;
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
                            case "image":
                                XmlNodeList imgList = channel_item.ChildNodes;
                                foreach(XmlNode imgItem in imgList)
                                {
                                    switch(imgItem.Name)
                                    {
                                        case "url":
                                            imageChanel.imgURL = imgItem.InnerText;
                                            break;
                                        case "link":
                                            imageChanel.imgLink = imgItem.InnerText;
                                            break;
                                        case "title":
                                            imageChanel.imgTitle = imgItem.InnerText;
                                            break;
                                    }
                                }
                                break;
                            case "item":
                                XmlNodeList itemsList = channel_item.ChildNodes;                                
                                articles[count] = new RssItem();
                                foreach(XmlNode item in itemsList)
                                    switch(item.Name)
                                    {
                                        case "title":
                                            articles[count].title = item.InnerText;
                                            break;
                                        case "link":
                                            articles[count].link = item.InnerText;
                                            break;
                                        case "description":
                                            articles[count].description = item.InnerText;
                                            break;
                                        case "pubDate":
                                            articles[count].pubData = item.InnerText;
                                            break;
                                    }
                                ++count;
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

    }

    

}
