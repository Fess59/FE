using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._1_DAL
{
    public class BaseObject
    {
         public Guid Id { get; set; }
         public DateTime Create { get; set; }
         public DateTime Timestamp { get; set; }
        public BaseObject()
        {
            Id = Guid.Empty;
            Create = DateTime.Now;
            Timestamp = DateTime.Now;
        }
        public void Change()
        {
            Timestamp = DateTime.Now;
        }
    }
}
