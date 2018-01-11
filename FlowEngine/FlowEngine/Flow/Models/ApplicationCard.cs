using FlowEngineV1._1_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Карточка приложения выполняющего запросы
    /// </summary>
    public class ApplicationCard : BaseEntityObject
    {
        /// <summary>
        /// Наименование приложения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Признак блокировки
        /// </summary>
        public bool HasBlocked { get; set; }
        //1. Добавить блокирвку по таймингу
        //2. Добавить таблицу лицензий - история, в текущей хранить дату последней рабочей
    }
}
