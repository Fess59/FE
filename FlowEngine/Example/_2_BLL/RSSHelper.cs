using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Example.RSS
{
    /// <summary>
    /// Сбор данные с RSS лент
    /// </summary>
    public static class RSSHelper
    {
        public static List<Proxy> List = new List<Proxy>();
        static IEnumerable<string> RSSList = new string[] { $"http://www.xroxy.com/proxyrss.xml", $"http://www.xroxy.com/xorum/rss.php?c=5", $"http://www.freeproxylists.com/rss", $"http://www.proxz.com/proxylists.xml" };
        /// <summary>
        /// Получаем актуальный список Proxy
        /// </summary>
        public static void Execute()
        {
            LogHelper.Execute(() => {

                foreach (var url in RSSList)
                {
                    XmlReader FeedReader = XmlReader.Create(url);
                    SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);
                    if (Channel != null)
                    {
                        // обрабатываем каждую новость канала
                        foreach (SyndicationItem RSI in Channel.Items)
                        {
                            LogHelper.SendMessage(RSI.Title.Text);
                            foreach (var item in RSI.ElementExtensions)
                            {
                                var reader = item.GetReader();
                                LogHelper.SendMessage(reader.Value);
                            }
                            // создаем элемент для вывода в ListView
                        }
                    }
                }


                //// если загрузились
                //if (Channel != null)
                //{
                //    // обрабатываем каждую новость канала
                //    foreach (SyndicationItem RSI in Channel.Items)
                //    {
                //        // создаем элемент для вывода в ListView
                //        ListViewItem LVI = new ListViewItem(RSI.Title.Text);
                //        LVI.Name = RSI.Title.Text;
                //    }
                //}
            });
        }
    }

    public class Proxy
    {

    }
}
