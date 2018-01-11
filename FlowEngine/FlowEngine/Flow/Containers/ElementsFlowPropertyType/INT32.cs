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
    public class INT32 : ElementFlowPropertyType
    {
        public INT32() : base(FlowPropertyType.Int32)
        {
        }
        public override bool Execute(ParamsFlowPropertyType obj)
        {
            var result = false;
            try
            {
                var oldValueInt = int.Parse(obj.OldValue);
                var newValueInt = int.Parse(obj.NewValue);
                switch (obj.ConditionType)
                {
                    case ActivityConditionPropertyType.EQUALS:
                        result = oldValueInt == newValueInt;
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
