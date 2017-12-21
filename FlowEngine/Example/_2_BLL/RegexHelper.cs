using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Example._2_BLL
{
    public static class RegexHelper
    {
        public static IEnumerable<Match> Execute(string regexStr, string text)
        {
            var result = Enumerable.Empty<Match>();
            LogHelper.Execute(()=>{
                Regex regex = new Regex(regexStr, RegexOptions.Compiled);
                MatchCollection matches = regex.Matches(text);
                var list = new List<Match>();
                foreach (var match in matches)
                    list.Add(match as Match);
                result = list.ToArray();
            });
            return result;
        }
        public static bool Check(string regexStr, string text)
        {
            var result = false;
            LogHelper.Execute(() => {
                Regex regex = new Regex(regexStr, RegexOptions.Compiled);
                result = regex.IsMatch(text);
            });
            return result;
        }
    }
}
