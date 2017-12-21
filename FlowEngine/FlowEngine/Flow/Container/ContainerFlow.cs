using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngine.Tools.Container
{
    public class FlowEventContainer
    {
        /// <summary>
        /// Базовый класс контейнера - контейнер ициализируются единожды и используется на чтение
        /// </summary>
        /// <typeparam name="T"></typeparam>
        //    public class ContainerFlow<T> where T : IOContainer<>
        //    {  
        //        /// <summary>
        //        /// Запускает 
        //        /// </summary>
        //        /// <param name="eventUID"></param>
        //        public void Execute(string eventUID) 
        //        {
        //            if (string.IsNullOrWhiteSpace(eventUID))
        //                throw new NullReferenceException("");
        //            //TODO #25 

        //        }


        //        #region Property
        //        private List<T> Collection = new List<T>();
        //        #endregion
        //        #region Constructor
        //        public ContainerBase(IEnumerable<T> elements)
        //        {
        //            try
        //            {
        //                AddRange(elements);
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.SendMessage(ex.ToString());
        //            }
        //        }
        //        #endregion
        //        #region Methods
        //        public bool Execute()
        //        {
        //            var result = false;
        //            try
        //            {

        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.SendMessage(ex.ToString());
        //            }
        //            return result;
        //        }
        //        private void AddRange(IEnumerable<T> collection)
        //        {
        //            foreach (var item in collection)
        //            {
        //                if (Collection.Any(q => q.UID == item.UID))
        //                    throw new Exception("ContainerBase.Addrange повторяющийся элемент в контейнере");
        //                Collection.Add(item);
        //            }
        //        }
        //        #endregion
        //    }
    }
}
