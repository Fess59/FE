using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._1_DAL
{
    public class AIObject : BaseObject
    {
        public class AvitoItem
        {
            public string AvitoId { get; set; }
            public string AvitoType { get; internal set; }
            public int Price { get; internal set; }
            public string PageURL { get; internal set; }
            public string AvitoId2 { get; internal set; }
            public string Address { get; internal set; }
            public string ImageCount { get; internal set; }
            public string TitleAlias { get; internal set; }
            public string Title { get; internal set; }
            public bool IsChecked { get; internal set; }
            public int Count { get; set; }
            public int CountPlus { get; internal set; }
            public string Decription { get; internal set; }
        }
        public class AvitoItemInfo : BaseObject
        {
            public int Count { get; set; }
            public int CountPlus { get; internal set; }
            public string Decription { get; internal set; }
        }
    }
}
