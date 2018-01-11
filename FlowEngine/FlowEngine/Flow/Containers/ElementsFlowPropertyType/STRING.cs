using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Containers;
using FlowEngineV1._2_BLL;

namespace FlowEngineV1.Flow.Containers.ElementsFlowPropertyType
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
