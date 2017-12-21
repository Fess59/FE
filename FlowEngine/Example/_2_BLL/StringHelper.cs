using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._2_BLL
{
    internal static class StringHelper
    {
        internal static string DefaultChecker(string s, Func<string, string> act)
        {
            var result = "Ошибка";
            LogHelper.Execute(() =>
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    result = "";
                    return;
                }
                result = RemoveLineBreak(s);
                result = act?.Invoke(result);
                result = result.Replace("  ", " ");
                result = result.Trim();
            });
            return result;
        }
        internal static string RemoveLineBreak(string s)
        {
            s = s.Replace(Environment.NewLine, "");
            s = s.Replace("\r\n", "");
            s = s.Replace("\n", "");
            return s;
        }
    }
}
