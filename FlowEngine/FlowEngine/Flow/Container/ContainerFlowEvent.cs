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
    public class ContainerFlowEvent : IOContainerExecute<ElementFlowEvent, FlowEvent, FlowInstance>
    {
        #region Methods
        public override string GetUID(FlowInstance obj)
        {
            return obj.EventUID;
        }
        #endregion
        #region Static methods
        public static ContainerFlowEvent New(IEnumerable<FlowEvent> events)
        {
            var result = new ContainerFlowEvent();
            result.AddRange(events.Select(q => ElementFlowEvent.New(q)));
            return result;
        }
        #endregion


       
    }
}
