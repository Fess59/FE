using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models.FlowInstancesParameters
{
    internal class FlowInstanceParametersHelper
    {
        internal static FlowInstanceParameters CreateToQueued(FlowInstanceParameters arg1, FlowInstanceParameters arg2)
        {
            arg1.FlowInstanceId = arg2.FlowInstanceId;
            arg1.ObejctProperty = arg2.ObejctProperty;
            arg1.ObjectState = arg2.ObjectState;
            return arg1;
        }
    }
}
