using GateDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models.FlowInstances
{
    /// <summary>   A flow instance helper.
    ///             Логика жизненного цикла объекта FlowInstance </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 08.02.2018. </remarks>

    internal static class FlowInstanceHelper
    {
        public static FlowInstance CreateToCreate(FlowInstance _old, FlowInstance _new)
        {
            _old.Token = _new.Token;
            _old.ObjectUID = _new.ObjectUID;
            _old.FlowUID = _new.FlowUID;
            return _old;
        }
        public static FlowInstance CreateToAwait(FlowInstance _old, FlowInstance _new)
        {
            _old.Token = _new.Token;
            _old.ObjectUID = _new.ObjectUID;
            _old.FlowUID = _new.FlowUID;
            return _old;
        }
    }
}
