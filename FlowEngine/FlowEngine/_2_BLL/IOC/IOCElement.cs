using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools.Container
{
    /// <summary>
    /// Базовый элемент контейнера для хранения и повторного использования объектов
    /// </summary>
    public class IOCElement: BaseObject
    {
        /// <summary>
        /// Уникальный ключ элемента контейнера
        /// </summary>
        public string UID { get; set; }
    }
}
