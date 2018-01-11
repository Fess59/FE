using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Containers.ElementsConditionGroup;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Containers
{
    public class ContainerConditionGroup : IOContainerExecute<ElementConditionGroup, ActivityConditionGroupType, ParamsConditionGroup>
    {
        public bool Execute(ActivityConditionGroupType type, IEnumerable<bool> value)
        {
            return Execute(ParamsConditionGroup.New(type, value));
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
