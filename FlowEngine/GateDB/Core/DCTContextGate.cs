using FessooFramework.Components;
using FessooFramework.Components.LoggerComponent;
using GateDB.Context;
using GateDB.Models.FlowInstances;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Core
{
    /// <summary>   A dct context. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 07.02.2018. </remarks>

    public class DCTContextGate : DCTContext
    {
        public DCTContextGate()
        {
            _Store.Add<GateDBContext>();
        }
        public DbSet<FlowInstance> FlowInstances {  get { return DbSet<FlowInstance>(); } }
    }
}
