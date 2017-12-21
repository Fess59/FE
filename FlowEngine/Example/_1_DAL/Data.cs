using Example._1_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Example._1_DAL.AIObject;

namespace Example
{
    public static class Data
    {
        public static List<AvitoItem> AvitoItems = new List<AvitoItem>();
        public static List<ProxyResource> ProxyResources = new List<ProxyResource>();
        public static List<ProxyObject> ProxyObjects = new List<ProxyObject>();

        static Data()
        {
            SetDefault();
        }
        public static void ReplaceProxy(ProxyObject o, Func<ProxyObject, ProxyObject> action = null)
        {
            LogHelper.Execute(() => {
                ProxyObjects.Remove(o);
                o = action?.Invoke(o);
                o.Change();
                ProxyObjects.Add(o);
            });
        }
        private static void SetDefault()
        {
            LogHelper.Execute(() => {
                ProxyResources.Add(new ProxyResource() { Url = $"https://hidemy.life/en/proxy-list-servers" });
                ProxyResources.Add(new ProxyResource() { Url = $"http://www.xroxy.com/proxyrss.xml", Regex= @"<prx:ip>(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})</prx:ip>[\s,\S,\n]*?<prx:port>(\d{1,8}\b)</prx:port>" });
                ProxyResources.Add(new ProxyResource() { Url = $"https://webanetlabs.net/freeproxylist/proxylist_at_02.12.2017.txt"});
            });
        }
    }
}
