using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Containers
{
    public class ParamsFlowElement : IOCElementExecuteParams
    {
        public ParamsFlowElement(string uid) : base(uid)
        {
        }
        public FlowInstance Value { get; set; }
        public static ParamsFlowElement New(FlowInstance value)
        {
            var result = new ParamsFlowElement(value.EventUID);
            result.Value = value;
            return result;
        }
    }
}
