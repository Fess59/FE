using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models.FlowInstances
{
    public enum FlowInstanceState
    {
        Create = 0,
        Await = 1,
        Comleted = 2,
        Error = 3
    }
}
