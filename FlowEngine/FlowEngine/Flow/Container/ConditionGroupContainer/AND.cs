using FlowEngine.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowEngineV1.Flow.Models;

namespace FlowEngineV1.Flow.Container.ConditionGroupContainer
{
    public class AND : ElementConditionGroup
    {
        public AND() : base(ActivityConditionGroupType.AND)
        {
        }
        public override bool Execute(ActivityConditionGroupType obj)
        {
            return base.Execute(obj);
        }
    }
}
