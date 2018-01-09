using FlowEngine.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowEngineV1.Flow.Models;

namespace FlowEngineV1.Flow.Container.ElementsFlowPropertyType
{
    public class STRING : ElementFlowPropertyType
    {
        public STRING() : base(FlowPropertyType.String)
        {
        }
        public override bool Execute(ParamsFlowPropertyType obj)
        {
            var result = false;
            try
            {
                switch (obj.ConditionType)
                {
                    case ActivityConditionPropertyType.EQUALS:
                        result = obj.OldValue == obj.NewValue;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.SendMessage(ex.ToString());
            }
            return result;
        }
    }
}
