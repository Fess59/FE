using FlowEngine.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowEngineV1.Flow.Models;

namespace FlowEngineV1.Flow.Container.ElementsConditionGroup
{
    public class OR : ElementConditionGroup
    {
        public OR() : base(ActivityConditionGroupType.OR)
        {
        }
        public override bool Execute(ParamsConditionGroup obj)
        {
            var result = false;
            if (obj.Value != null)
                result = obj.Value.All(q => !q);
            return result;
        }
    }
}
