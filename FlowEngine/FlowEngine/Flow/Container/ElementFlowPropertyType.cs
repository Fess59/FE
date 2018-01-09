using FlowEngineV1;
using FlowEngineV1.Flow;
using FlowEngineV1.Flow.Container;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngine.Tools.Container
{
    public class ElementFlowPropertyType : IOCElementExecute<FlowPropertyType, ParamsFlowPropertyType>
    {
        #region Constructor
        public ElementFlowPropertyType(FlowPropertyType element) : base(element)
        {
        }
        #endregion
        #region Method
        public override string GetUID(FlowPropertyType element)
        {
            return element.ToString();
        }
        #endregion
    }
}
