using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRegExExample
{
    class Program
    {
        static void Main(string[] args)
        {
            GetList();
            //ParseList(Properties.Resources.html);
            //ParseOne(Properties.Resources.html2);
            Console.ReadLine();
        }
        #region Models
        public class AvitoItem
        {
            #region Property
            public Guid Id { get; set; }
            public DateTime Create { get; set; }
            public string AvitoId { get; set; }
            public string AvitoType { get; internal set; }
            public string Price { get; internal set; }
            public string PageURL { get; internal set; }
            public string AvitoId2 { get; internal set; }
            public string Address { get; internal set; }
            public string ImageCount { get; internal set; }
            public string TitleAlias { get; internal set; }
            public string Title { get; internal set; }
            public bool IsChecked { get; internal set; }
            public AvitoItemInfo Info { get; internal set; }

            #endregion
            #region Constructor
            public AvitoItem()
            {
                Id = Guid.NewGuid();
                Create = DateTime.Now;
            }
            #endregion
        }
        public class AvitoItemInfo
        {
            #region Property
            public Guid Id { get; set; }
            public DateTime Create { get; set; }
            public string Count { get; set; }
            public string CountPlus { get; internal set; }
            public string Decription { get; internal set; }
            #endregion
            #region Constructor
            public AvitoItemInfo()
            {
                Id = Guid.NewGuid();
                Create = DateTime.Now;
            }
            #endregion
        }
        #endregion
        #region GetData
        public static List<AvitoItem> list = new List<AvitoItem>();

        public static void GetList()
        {
            try
            {
                var pageIndex = 0;
                while (true)
                {
                    pageIndex++;
                    var mainUrl = $"https://www.avito.ru";
                    var url = mainUrl + $"/moskva/ohota_i_rybalka?p={pageIndex}&s=101&view=list";
                    var html = GetHttp(url);
                    if (AwaitUnblocking(html))
                        continue;
                    var pageItems = ParseList(html, mainUrl);
                    Log("Http " + pageIndex + " complite");
                    if (!pageItems.Any())
                        break;
                    list.AddRange(pageItems);
                    Thread.Sleep(5000);
                }
                while (true)
                {
                    if (list.All(q => q.IsChecked))
                        break;
                    var item = list.FirstOrDefault();
                    var urlPage = item.PageURL;
                    var htmlPage = GetHttp(urlPage);
                    if (AwaitUnblocking(htmlPage))
                        continue;
                    var info = ParseOne(htmlPage);
                    if (info == null)
                        continue;
                    list.Remove(item);
                    item.Info = info;
                    item.IsChecked = true;
                    list.Add(item);
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
            finally
            {
                Log("Complete Get");
            }
        }
        static bool AwaitUnblocking(string html)
        {
            if (html.Contains("Доступ временно заблокирован"))
            {
                Thread.Sleep(60000);
                return true;
            }
            return false;
        }
        #endregion
        #region One
        static AvitoItemInfo ParseOne(string html)
        {
            AvitoItemInfo result = null;
            try
            {
                Regex regex = new Regex(Properties.Resources.Regex2, RegexOptions.Compiled);
                MatchCollection matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    int index = 0;
                    foreach (Match match in matches)
                    {
                        index++;
                        var count = match.Groups[1];
                        var countPlus = match.Groups[2];
                        var description = Description(match.Groups[3].ToString());
                        result = new AvitoItemInfo();
                        result.Count = count.ToString();
                        result.CountPlus = countPlus.ToString();
                        result.Decription = description.ToString();
                        //var result = $"[{index}][{DateTime.Now.ToString("o")}] count={count}, countPlus={countPlus}, description={description}";
                        //Console.WriteLine(result);
                    }
                }
                else
                    Log("Совпадений не найдено");
            }
            catch (Exception)
            {
            }
            return result;
        }
        static string Description(string s)
        {
            return DefaultChecker(s, result =>
            {
                result = result.Replace("</p>", "");
                result = result.Replace("<p>", "");
                result = result.Replace("<br />", " ");
                return result;
            });
        }
        #endregion
        #region List
        static IEnumerable<AvitoItem> ParseList(string html, string mainUrl)
        {
            var result = new List<AvitoItem>();
            try
            {
                Regex regex = new Regex(Properties.Resources.Regex1, RegexOptions.Compiled);
                MatchCollection matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    int index = 0;
                    foreach (Match match in matches)
                    {
                        index++;
                        var id = match.Groups[1];
                        var type = match.Groups[2];
                        var price = Price(match.Groups[3].ToString());
                        var fotoCount = Foto(match.Groups[4].ToString());
                        var address = Address(match.Groups[5].ToString());
                        var id2 = match.Groups[6];
                        var url = match.Groups[7];
                        var titleAlias = match.Groups[8];
                        var title = Title(match.Groups[9].ToString());
                        var item = new AvitoItem();
                        item.AvitoId = id.ToString();
                        item.AvitoType = type.ToString();
                        item.Price = price;
                        item.ImageCount = fotoCount;
                        item.Address = address;
                        item.AvitoId2 = id2.ToString();
                        item.PageURL = mainUrl + url;
                        item.TitleAlias = titleAlias.ToString();
                        item.Title = title;
                        result.Add(item);
                        //var r11 = match.Groups[10];
                        //var result = $"[{index}][{DateTime.Now.ToString("o")}] Id={id}, Type={type}, Price={price}, Address ={ address}, Id2={ id2}, URL={ url}, TitleAlice={titleAlice}, Title={title}, FotoCount={fotoCount}";
                    }
                }
                else
                {
                    Log("Совпадений не найдено");
                }
            }
            catch (Exception)
            {
            }
            return result.ToArray();
        }
        static string Price(string s)
        {
            return DefaultChecker(s, result =>
            {
                result = result.Replace("&#160;р.", "");
                result = result.Replace("<span class=\"nw\">", "");
                result = result.Replace("</span>", "");
                result = result.Replace("<span class=\"c-2\">", "");
                result = result.Replace("Зарплата не указана", "0");
                result = result.Replace("Цена не указана", "0");
                result = result.Replace("Договорная", "0");
                return result;
            });
        }
        static string Address(string s)
        {
            return DefaultChecker(s, result =>
            {
                result = result.Replace("<p class=\"nw fader\">", "");
                result = result.Replace("</p>", "");
                result = result.Replace("<p class=\"\">", "");
                result = result.Replace("<p class=\"c-2\">", "");
                return result;
            });
        }
        static string Title(string s)
        {
            return DefaultChecker(s, result =>
            {
                result = result.Replace("<span class=\"nobr\">", "");
                result = result.Replace("</span>", "");
                return result;
            });
        }
        static string Foto(string s)
        {
            return DefaultChecker(s, result =>
            {
                if (result.Contains("фотографий"))
                    result = result.Remove(0, result.IndexOf("фотографий"));
                if (result.Contains("фотографией"))
                    result = result.Remove(0, result.IndexOf("фотографией"));
                if (result.Contains("фотографии"))
                    result = result.Remove(0, result.IndexOf("фотографии"));
                result = result.Replace("фотографий\">", "");
                result = result.Replace("фотографией\">", "");
                result = result.Replace("фотографии\">", "");
                result = result.Replace("<span class=\"nobr\">", "");
                result = result.Replace("</i>", "");
                result = result.Replace("<i class=\"i i-video\">", "");
                result = result.Replace("</a>", "");
                return result;
            });
        }
        #endregion
        #region String helper
        static string DefaultChecker(string s, Func<string, string> act)
        {
            var result = "Ошибка";
            try
            {
                if (string.IsNullOrWhiteSpace(s))
                    return result;
                result = RemoveLineBreak(s);
                result = act?.Invoke(result);
                result = result.Replace("  ", " ");
                result = result.Trim();
            }
            catch (Exception ex)
            {
                var r = ex.ToString();
            }
            return result;
        }
        static string RemoveLineBreak(string s)
        {
            s = s.Replace(Environment.NewLine, "");
            s = s.Replace("\r\n", "");
            s = s.Replace("\n", "");
            return s;
        }
        static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("o")}] {message}");
        }
        #endregion
        #region Connection
        private static string GetHttp(string url)
        {
            var result = "";
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    // Выполняем запрос по адресу и получаем ответ в виде строки
                    var response = webClient.DownloadString(url);
                    result = response;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        #endregion
    }
}
