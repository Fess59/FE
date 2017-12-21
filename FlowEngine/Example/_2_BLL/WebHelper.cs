using Example._1_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Example._2_BLL
{
    internal static class WebHelper
    {
        internal static string GetHttpWithProxy(string url)
        {
            var result = "";
            LogHelper.Execute(() =>
            {
                var proxy = Data.ProxyObjects.Where(q => !q.IsBlocked).OrderBy(q => q.Timestamp).ThenBy(q => q.Ping).FirstOrDefault();
                if (proxy != null)
                    Data.ReplaceProxy(proxy);
                result = GetHttp(url, proxy);
            });
            return result;
        }

        internal static string GetHttp(string url, ProxyObject proxy = null)
        {
            var result = "";
            LogHelper.Execute(() =>
            {
                try
                {
                    using (var webClient = new WebClient())
                    {
                        if (proxy != null)
                            webClient.Proxy = proxy.GetWebProxy();
                        //webClient.Proxy = new WebProxy(" proxy server url here");
                        webClient.Encoding = Encoding.UTF8;
                        // Выполняем запрос по адресу и получаем ответ в виде строки
                        var response = webClient.DownloadString(url);
                        result = response;
                    }

                }
                catch (Exception ex)
                {
                    if (proxy != null)
                    {
                        Data.ReplaceProxy(proxy, a =>
                        {
                            a.IsBlocked = true;
                            return a;
                        });
                        result = GetHttpWithProxy(url);
                    }
                }
            });
            return result;
        }

    }
}
