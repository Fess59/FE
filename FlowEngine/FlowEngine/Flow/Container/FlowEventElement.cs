using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngine.Tools.Container
{
    public class FlowEventElement : IOCElement
    {
        public FlowEvent Event { get; private set; }
        public FlowEventElement(FlowEvent _event)
        {
            Event = _event;
        }
        public void Execute()
        {
          
        }
    }
}
