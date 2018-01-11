using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Containers;

namespace FlowEngineV1.Flow.Containers.ElementsConditionGroup
{
    public class AND : ElementConditionGroup
    {
        public AND() : base(ActivityConditionGroupType.AND)
        {
        }
        public override bool Execute(ParamsConditionGroup obj)
        {
            var result = false;
             if (obj.Value != null)
                result = obj.Value.Any(q => !q); 
            return result;
        }
    }
}
