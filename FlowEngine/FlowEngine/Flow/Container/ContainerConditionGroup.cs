using FlowEngine.Tools.Container;
using FlowEngineV1.Flow.Container.ConditionGroupContainer;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Container
{
    public class ContainerConditionGroup : IOContainerExecute<ElementConditionGroup, ActivityConditionGroupType, ActivityConditionGroupType>
    {
        public override string GetUID(ActivityConditionGroupType obj)
        {
            return obj.ToString();
        }
        public static ContainerConditionGroup New()
        {
            var result = new ContainerConditionGroup();
            result.Add(new AND());
            result.Add(new OR());
            return result;
        }
    }
}
