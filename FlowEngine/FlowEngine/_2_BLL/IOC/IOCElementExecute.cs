using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools.Container
{
    /// <summary>
    /// Базовый контейнер для хранения и повторного использования объектов
    /// </summary>
    /// <typeparam name="T">Тип родительского объекта</typeparam>
    /// <typeparam name="T">Тип испольняемого объекта</typeparam>
    public class IOCElementExecute<TElement, TParam>: IOCElement
    {
        public TElement Element { get; set; }
        public IOCElementExecute(TElement element)
        {
            Element = element;
            UID = GetUID(element);
        }
        /// <summary>
        /// Извлекаем уникальный идентификатор из объекта
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public virtual string GetUID(TElement element)
        {
            throw new NotImplementedException($"IOCElementExecute {UID}. Метод Execute не реализован");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Execute(TParam obj)
        {
            throw new NotImplementedException($"IOCElementExecute {UID}. Метод Execute не реализован");
        }
    }
}
