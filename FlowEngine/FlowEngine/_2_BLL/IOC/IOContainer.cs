using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools.Container
{
    /// <summary>
    /// Базовый класс контейнера - контейнер ициализируются единожды и используется на чтение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IOContainer<T> : BaseObject where T : IOCElement, new()
    {
        #region Property
        private List<T> Collection = new List<T>();
        public string ContainerName { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Создаем пустой контейнер
        /// </summary>
        public IOContainer()
        {
           
        }
        /// <summary>
        /// Создаём контейнер на основе коллекции - рекомендуемый способ использования для ReadOnly коллекций, внутри потоков
        /// </summary>
        /// <param name="elements">Список элементов</param>
        public IOContainer(IEnumerable<T> elements)
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
        /// <summary>
        /// Получение элемента контейнера по уникальному ключу
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public T GetByName(string uid)
        {
            T result = default(T);
            if (Collection == null && !Collection.Any())
                return result;
            result = Collection.FirstOrDefault(q=>q.UID == uid);
            return result;
        }
        /// <summary>
        /// Добавить коллекцию элементов в контейнер
        /// </summary>
        /// <param name="collection"></param>
        public void Add(T element)
        {
            AddRange(new T[] { element });
        }
        /// <summary>
        /// Добавить коллекцию элементов в контейнер
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                if (Collection.Any(q => q.UID == item.UID))
                    throw new Exception("ContainerBase.AddRange повторяющийся элемент в контейнере");
                Collection.Add(item);
            }
        }
        #endregion
    }
}