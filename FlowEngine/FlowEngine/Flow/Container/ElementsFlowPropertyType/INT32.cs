using FlowEngine.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowEngineV1.Flow.Models;

namespace FlowEngineV1.Flow.Container.ElementsFlowPropertyType
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
