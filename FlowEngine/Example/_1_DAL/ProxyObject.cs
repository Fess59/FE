using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Example._1_DAL
{
    public class ProxyObject : BaseObject
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public string ParentURL { get; set; }
        public bool IsSSL{ get; set; }
        public ProxyType ProxyType { get; set; }
        /// <summary>
        /// Если прокси не прошла по формату
        /// </summary>
        public bool IsFormatBlocked { get; set; }

        internal WebProxy GetWebProxy()
        {
            WebProxy result = new WebProxy(Ip, Port);
            //WebProxy result = new WebProxy($"{Ip}:{Port}");
            //LogHelper.Execute(() => {
            //    var format = IsSSL ? "http" : "https";
            //    result.Address =new Uri($"{Ip}:{Port}");
            //});
            return result;
        }

        /// <summary>
        /// Если прокси заблокирована
        /// </summary>
        public bool IsBlocked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Ping { get; set; }

        public override string ToString()
        {
            return $"{Ip}:{Port}";
        }
    }

    public enum ProxyType
    {
        None = 0,
    }
}
