using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools.Container
{
    /// <summary>
    /// Базовый контейнера для хранения логики и обработки на основе входящего параметра
    /// </summary>
    /// <typeparam name="TElement">Element type</typeparam>
    /// <typeparam name="TParam">Execute param type</typeparam>
    public class IOContainerExecute<TIOCType, TElement, TParam> : IOContainer<TIOCType> 
        where TIOCType : IOCElementExecute<TElement, TParam>
        where TParam : IOCElementExecuteParams
    {
        #region Constructor
        /// <summary>
        /// Создаем пустой контейнер
        /// </summary>
        public IOContainerExecute()
        {
           
        }
        /// <summary>
        /// Создаём контейнер на основе коллекции - рекомендуемый способ использования для ReadOnly коллекций, внутри потоков
        /// </summary>
        /// <param name="elements">Список элементов</param>
        public IOContainerExecute(IEnumerable<TIOCType> elements)
        {
            try
            {
                AddRange(elements);
            }
            catch (Exception ex)
            {
                Logger.SendMessage(ex.ToString());
            }
        }
        #endregion
        #region Methods
        public bool Execute(TParam obj)
        {
            var result = false;
            if (obj == null)
                throw new NullReferenceException($"IOContainerExecute {ContainerName} Параметр не может быть NULL");
            if (string.IsNullOrWhiteSpace(obj.UID))
                throw new NullReferenceException("Уникальный ключ UID не может быть пустым");
            var e = GetByName(obj.UID);
            if (e == null)
            {
                //TODO #25 здесь генератор Event'ов
                throw new NullReferenceException($"IOContainerExecute {ContainerName} Указанный элемент не найден в контейнере");
            }
            else
                result = e.Execute(obj);
            return result;
        }
        /// <summary>
        /// Преобразует объект в уникальный ключ UID
        /// </summary>
        /// <returns></returns>
        public virtual string GetUID(TParam obj)
        {
            throw new NotImplementedException($"IOContainerExecute {ContainerName} Метод формиравания уникального ключа не реализован");
        }
        #endregion
    }
}