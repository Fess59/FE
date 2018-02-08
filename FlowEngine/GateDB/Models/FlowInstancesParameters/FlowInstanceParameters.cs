using FessooFramework.Objects.Data;
using FessooFramework.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models.FlowInstancesParameters
{
    /// <summary>   A flow instance parameters. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

    public class FlowInstanceParameters : EntityObjectALM<FlowInstanceParameters, FlowInstanceParametersState>
    {
        /// <summary>   Gets or sets the identifier of the flow instanc model. </summary>
        ///
        /// <value> The identifier of the flow instance. </value>

        public Guid FlowInstanceId { get; set; }

        /// <summary>   Gets or sets the state of the object.
        ///             Состояние принятое объектом </summary>
        ///
        /// <value> The object state. </value>

        public string ObjectState { get; set; }

        /// <summary>   Gets or sets the obejct property.
        ///             Данные для обработки в логическом блок системы - будут переданы в выполняемые блоки</summary>
        ///
        /// <value> The obejct property. </value>
        public string ObejctProperty { get; set; }

        #region Methods
        internal static FlowInstanceParameters New(Guid flowInstanceId, string objectState, string obejctProperty)
        {
            return new FlowInstanceParameters()
            {
                FlowInstanceId = flowInstanceId,
                ObjectState = objectState,
                ObejctProperty = obejctProperty,
            };
        }
        #endregion
        #region ALM
        protected override IEnumerable<EntityObjectALMConfiguration<FlowInstanceParameters, FlowInstanceParametersState>> Configurations => new[]
        {
            EntityObjectALMConfiguration<FlowInstanceParameters, FlowInstanceParametersState>.New(FlowInstanceParametersState.Create, FlowInstanceParametersState.Queued, FlowInstanceParametersHelper.CreateToQueued)
        };
        protected override IEnumerable<FlowInstanceParametersState> DefaultState => new[] { FlowInstanceParametersState.Create };
        protected override int GetStateValue(FlowInstanceParametersState state)
        {
            return (int)state;
        }
        #endregion
    }
}
