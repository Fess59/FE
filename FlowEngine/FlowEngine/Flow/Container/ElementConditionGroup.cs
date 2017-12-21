using FlowEngineV1;
using FlowEngineV1.Flow;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngine.Tools.Container
{
    public class ElementConditionGroup : IOCElementExecute<ActivityConditionGroupType, ActivityConditionGroupType>
    {
        public ElementConditionGroup(ActivityConditionGroupType element) : base(element)
        {
        }
        public override string GetUID(ActivityConditionGroupType element)
        {
            return element.ToString();
        }
    }
}
