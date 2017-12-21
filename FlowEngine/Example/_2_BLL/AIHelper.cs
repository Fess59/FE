using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static Example._1_DAL.AIObject;

namespace Example._2_BLL
{

    internal static class AIHelper
    {
        static string MainUrl = "";
        public static void Execute(string path = "moskva/ohota_i_rybalka")
        {
            Task.Factory.StartNew(() => getActualList(path));
        }
        static void getActualList(string path = "moskva/ohota_i_rybalka")
        {
            LogHelper.Execute(() =>
            {
                getList($"/{path}?s=2&view=list");
                getList($"/{path}?s=1&view=list");
                getList($"/{path}?s=101&view=list");
                Task.Factory.StartNew(() =>
                {
                    MessageBox.Show("Complite list");
                });
                while (true)
                {
                    if (Data.AvitoItems.All(q => q.IsChecked))
                        break;
                    var item = Data.AvitoItems.Where(q => !q.IsChecked).FirstOrDefault();
                    var urlPage = item.PageURL;
                    var htmlPage = WebHelper.GetHttpWithProxy(urlPage);
                    if (string.IsNullOrWhiteSpace(htmlPage))
                        continue;
                    if (AwaitUnblocking(htmlPage))
                        continue;
                    var info = ParseOne(htmlPage);
                    if (info == null)
                        continue;
                    Data.AvitoItems.Remove(item);
                    item.Count = info.Count;
                    item.CountPlus = info.CountPlus;
                    item.Decription = info.Decription;
                    item.IsChecked = true;
                    Data.AvitoItems.Add(item);
                    Thread.Sleep(3000);
                }
            });
        }
        static void getList(string listUrl)
        {
            LogHelper.Execute(() =>
            {
                var pageIndex = 0;
                while (true)
                {
                    pageIndex++;
                    var mainUrl = $"https://www.avito.ru";
                    var url = mainUrl + listUrl + $"&p={pageIndex}";
                    if (pageIndex > 100)
                        break;
                    var html = WebHelper.GetHttpWithProxy(url);
                    if (AwaitUnblocking(html))
                        continue;
                    var pageItems = ParseList(html, mainUrl);
                    LogHelper.SendMessage("Http " + pageIndex + " complite");
                    if (!pageItems.Any())
                        break;
                    foreach (var item in pageItems)
                    {
                        if (!Data.AvitoItems.Any(q => q.AvitoId == item.AvitoId))
                            Data.AvitoItems.Add(item);
                    }
                    Thread.Sleep(3000);
                }
            });
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
        #region One
        static AvitoItemInfo ParseOne(string html)
        {
            AvitoItemInfo result = null;
            LogHelper.Execute(() =>
            {
                var matches = RegexHelper.Execute(Properties.Resources.Regex2, html);
                if (matches.Count() > 0)
                {
                    int index = 0;
                    foreach (Match match in matches)
                    {
                        index++;
                        var count = match.Groups[1];
                        var countPlus = match.Groups[2];
                        var description = Description(match.Groups[3].ToString());
                        result = new AvitoItemInfo();
                        result.Count = Count(count.ToString());
                        result.CountPlus = Count(countPlus.ToString());
                        result.Decription = description.ToString();
                        //var result = $"[{index}][{DateTime.Now.ToString("o")}] count={count}, countPlus={countPlus}, description={description}";
                        //Console.WriteLine(result);
                    }
                }
                else
                    LogHelper.SendMessage("Совпадений не найдено");
            });
            return result;
        }

        static int Count(string s)
        {
            var resultInt = 0;
            var str = StringHelper.DefaultChecker(s, result =>
            {
                if (s.Contains("js-show-stat pseudo-link"))
                    result = result.Remove(s.IndexOf("<a href=") - 1, s.IndexOf(">"));
                result = result.Replace("</p>", "");
                result = result.Replace("<p>", "");
                result = result.Replace(" ", "");
                return result;
            });
            try
            {
                resultInt = int.Parse(str);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resultInt;
        }
        static string Description(string s)
        {
            return StringHelper.DefaultChecker(s, result =>
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
            LogHelper.Execute(() =>
            {
                var matches = RegexHelper.Execute(Properties.Resources.Regex1, html);
                if (matches.Count() > 0)
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
                        item.PageURL = url.ToString().Contains("https://www.avito.ru") ? url.ToString() : mainUrl + url;
                        item.TitleAlias = titleAlias.ToString();
                        item.Title = title;

                        result.Add(item);
                        //var r11 = match.Groups[10];
                        //var result = $"[{index}][{DateTime.Now.ToString("o")}] Id={id}, Type={type}, Price={price}, Address ={ address}, Id2={ id2}, URL={ url}, TitleAlice={titleAlice}, Title={title}, FotoCount={fotoCount}";
                    }
                }
                else
                {
                    LogHelper.SendMessage("Совпадений не найдено");
                }
            });
            return result.ToArray();
        }
        static int Price(string s)
        {
            var resultint = -1;
            var str = StringHelper.DefaultChecker(s, result =>
            {
                result = result.Replace("&#160;р.", "");
                result = result.Replace("<span class=\"nw\">", "");
                result = result.Replace("</span>", "");
                result = result.Replace("<span class=\"c-2\">", "");
                result = result.Replace("Зарплата не указана", "0");
                result = result.Replace("Цена не указана", "0");
                result = result.Replace("Договорная", "0");
                result = result.Replace(" ", "");
                return result;
            });
            try
            {
                resultint = int.Parse(str);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resultint;
        }
        static string Address(string s)
        {
            return StringHelper.DefaultChecker(s, result =>
            {
                result = result.Replace("<p class=\"nw fader\">", "");
                result = result.Replace("</p>", "");
                result = result.Replace("<p class=\"\">", "");
                result = result.Replace("<p class=\"c-2\">", "");
                result = result.Replace("<p class=\"data-chunk\">", "");
                result = result.Replace("<p class=\"data-chunk fader\">", "");
                return result;
            });
        }
        static string Title(string s)
        {
            return StringHelper.DefaultChecker(s, result =>
            {
                result = result.Replace("<span class=\"nobr\">", "");
                result = result.Replace("</span>", "");
                return result;
            });
        }
        static string Foto(string s)
        {
            return StringHelper.DefaultChecker(s, result =>
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
    }
}
