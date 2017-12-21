using Example._1_DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Example._2_BLL.ProxyContainer
{
    public static class ProxyResourceHelper
    {
        private static string RegExString = @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\:(\d{1,8}\b)";
        public static string CheckString = @"^\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\:(\d{1,8}\b)$";
        private static string DefaultURL = $"http://ya.ru";
        public static void ExecuteAll()
        {
            LogHelper.Execute(() =>
            {
                foreach (var res in Data.ProxyResources)
                {
                    Execute(res.Url, res.Regex);
                }
            });
        }
        public static void Execute(string url, string regex = null)
        {
            LogHelper.Execute(() =>
            {
                if (string.IsNullOrWhiteSpace(regex))
                    regex = RegExString;
                var html = WebHelper.GetHttp(url);
                var matches = RegexHelper.Execute(regex, html);
                if (!matches.Any()) return;
                LogHelper.SendMessage($"Собрано {matches.Count()} c {url}");
                foreach (Match match in matches)
                {
                    try
                    {
                        var ip = match.Groups[1].ToString();
                        var port = match.Groups[2].ToString();
                        var proxy = new ProxyObject()
                        {
                            Ip = ip,
                            Port = int.Parse(port),
                            ParentURL = url
                        };
                        CheckAndAdd(proxy);
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }
        public static void SearchResources(string query, string fileType = null)
        {
            LogHelper.Execute(() => {
            var html = GSearchHelper.Search(query, count:10, fileType: fileType);
                foreach (var item in html)
                {
                    Execute(item);
                }
            });
        }
        private static bool CheckFormat(string ip, int port)
        {
            return RegexHelper.Check(CheckString, $"{ip}:{port}");
        }
        private static void CheckAndAdd(ProxyObject proxy)
        {
            LogHelper.ExecuteAsync(() =>
            {
                if (CheckFormat(proxy.Ip, proxy.Port))
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var htmlHttp = WebHelper.GetHttp(DefaultURL, proxy);
                    sw.Stop();
                    proxy.Ping = sw.ElapsedMilliseconds;
                    if (string.IsNullOrWhiteSpace(htmlHttp))
                        proxy.IsBlocked = true;
                    else
                    {
                        if (htmlHttp.Contains("Яндекс"))
                            proxy.IsBlocked = false;
                        else
                            proxy.IsBlocked = true;
                    }
                }
                else
                    proxy.IsBlocked = true;
                proxyAdd(proxy);
            });
        }
       static  object lockObj = new object();
        private static void proxyAdd(ProxyObject proxy)
        {
            LogHelper.Execute(() =>
            {
                lock (lockObj)
                {
                    var entity = Data.ProxyObjects.FirstOrDefault(q => q.Ip == proxy.Ip && q.Port == proxy.Port);
                    if (entity == null)
                        entity = proxy;
                    else
                    {
                        Data.ProxyObjects.Remove(entity);
                        entity.Change();
                    }
                    Data.ProxyObjects.Add(entity);
                    LogHelper.SendMessage($"Ping={proxy.Ping}, Proxy={proxy.ToString()}, State={proxy.IsBlocked} Count={Data.ProxyObjects.Count(q=>!q.IsBlocked)}");
                }
            });
        }
    }
}
