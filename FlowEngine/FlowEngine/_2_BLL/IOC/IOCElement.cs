using FlowEngineV1._1_DAL;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1._2_BLL.IOC
{
    /// <summary>
    /// Базовый элемент контейнера для хранения и повторного использования объектов
    /// </summary>
    public class IOCElement: BaseObject
    {
       public string UID { get; set; }
    }
}
