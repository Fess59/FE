using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Container
{
    public class ParamsFlowPropertyType : IOCElementExecuteParams
    {
        public ParamsFlowPropertyType(string uid) : base(uid)
        {
        }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public ActivityConditionPropertyType ConditionType { get; set; }

        internal static ParamsFlowPropertyType New(string newValue, string oldValue, ActivityConditionPropertyType conditionType, FlowPropertyType propertyType)
        {
            var result = new ParamsFlowPropertyType(propertyType.ToString());
            result.NewValue = newValue;
            result.OldValue = oldValue;
            result.ConditionType = conditionType;
            return result;
        }
    }
}
