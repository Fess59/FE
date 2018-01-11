using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Containers
{
    public class ParamsConditionGroup : IOCElementExecuteParams
    {
        public ParamsConditionGroup(string uid) : base(uid)
        {
        }
        public ActivityConditionGroupType ConditionGroupType { get; set; }
        public IEnumerable<bool> Value { get; set; }
        public static ParamsConditionGroup New(ActivityConditionGroupType type, IEnumerable<bool> value)
        {
            var result = new ParamsConditionGroup(type.ToString());
            result.ConditionGroupType = type;
            result.Value = value;
            return result;
        }
    }
}
