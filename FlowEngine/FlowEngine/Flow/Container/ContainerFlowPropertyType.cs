using FlowEngine.Tools.Container;
using FlowEngineV1.Flow.Container.ElementsFlowPropertyType;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Container
{
    public class ContainerFlowPropertyType : IOContainerExecute<ElementFlowPropertyType, FlowPropertyType, ParamsFlowPropertyType>
    {
        #region Methods
        internal bool Execute(string newValue, string oldValue, ActivityConditionPropertyType conditionType, FlowPropertyType propertyType)
        {
            return Execute(ParamsFlowPropertyType.New(newValue, oldValue, conditionType, propertyType));
        }
        #endregion
        #region Static methods
        public static ContainerFlowPropertyType New()
        {
            var result = new ContainerFlowPropertyType();
            result.Add(new STRING());
            result.Add(new INT32());
            return result;
        }
        #endregion
    }
}
