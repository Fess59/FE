using FessooFramework.Objects.ALM;
using GateDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Repozitory
{
    public class BaseRepository : ALMObject<FlowInstanceParametersState>
    {
        /// <summary>   Enumerates state configuration in this collection.
        ///             Настраиваем жизненный цикл объекта </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>
        ///
        /// <returns>
        ///     An enumerator that allows foreach to be used to process state configuration in this
        ///     collection.
        /// </returns>
        protected override IEnumerable<ALMConf<FlowInstanceParametersState>> _StateConfiguration()
        {
            return new ALMConf<FlowInstanceParametersState>[]
            {
                ALMConf<FlowInstanceParametersState>.New(FlowInstanceParametersState.Create, new [] { FlowInstanceParametersState.Queued }),
                ALMConf<FlowInstanceParametersState>.New(FlowInstanceParametersState.Queued, new [] { FlowInstanceParametersState.Processing, FlowInstanceParametersState.Suspended}),
                ALMConf<FlowInstanceParametersState>.New(FlowInstanceParametersState.Processing, new [] { FlowInstanceParametersState.Roolback, FlowInstanceParametersState.Complete}),
                ALMConf<FlowInstanceParametersState>.New(FlowInstanceParametersState.Roolback, new [] { FlowInstanceParametersState.Queued}),
                ALMConf<FlowInstanceParametersState>.New(FlowInstanceParametersState.Suspended, new [] { FlowInstanceParametersState.Queued}),
            };
        }
        /// <summary>   State changed. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>
        ///
        /// <param name="newState"> State of the new. </param>
        /// <param name="oldState"> State of the old. </param>
        protected override void _StateChanged(FlowInstanceParametersState newState, FlowInstanceParametersState oldState)
        {
            switch (newState)
            {
                case FlowInstanceParametersState.Create:
                    break;
                case FlowInstanceParametersState.Queued:
                    break;
                case FlowInstanceParametersState.Processing:
                    break;
                case FlowInstanceParametersState.Roolback:
                    break;
                case FlowInstanceParametersState.Suspended:
                    break;
                case FlowInstanceParametersState.Complete:
                    break;
                default:
                    break;
            }
        }
    }
}
