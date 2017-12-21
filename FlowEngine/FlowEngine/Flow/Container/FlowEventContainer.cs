using FlowEngineV1;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngine.Tools.Container
{
    /// <summary>
    /// Контейнер для службы или инстанции FlowEngine
    /// Предназначен для формирования на лету
    /// </summary>
    public class FlowEventContainer : IOContainer<FlowEventElement>
    {
        public static FlowEventContainer New(IEnumerable<FlowEvent> events)
        {
            var result = new FlowEventContainer();
            result.AddRange(events.Select(q => FlowEventElement.New(q)));
            return result;
        }

        /// <summary>
        /// Запускает 
        /// </summary>
        /// <param name="eventUID"></param>
        public bool Execute(FlowInstance instance)
        {
            var result = false;
            if (instance == null)
                throw new NullReferenceException("Инстанция не может быть NULL");

            if (string.IsNullOrWhiteSpace(instance.EventUID))
                throw new NullReferenceException("Идентификатор Event не может быть пустым");
            var e = GetByName(instance.EventUID);
            if (e == null)
            {
                //TODO #25 здесь генератор Event'ов
            }
            else
            {
                e.Execute(instance);
            }
            return result;
        }
    }
}
