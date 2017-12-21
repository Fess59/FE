using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._2_BLL
{
    public static class GSearchHelper
    {
        public static IEnumerable<string> Search(string query, int count=10, string lang="lang_en", string fileType = null)
        {
            var result = new List<string>();
            LogHelper.Execute(() => {
                if (!string.IsNullOrWhiteSpace(fileType))
                    query += $" filetype:{fileType}";
                var url = $"https://www.google.ru/search?q={query}&oq={query}&lr={lang}&num={count}";
                var html = WebHelper.GetHttp(url);
                //var results = RegexHelper.Execute($"<h3 class=\"r\"><a href=\"(http.*?)\" onm", html);
                var results = RegexHelper.Execute($"<h3 class=\"r\"><a href=\"/url.q=(.*?)&", html);

                foreach (var match in results)
                {
                    var r = match.Groups[1].ToString();
                    result.Add(r);
                }
            });
            return result;
        }
    }
}
