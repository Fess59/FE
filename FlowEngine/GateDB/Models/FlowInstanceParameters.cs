using FessooFramework.Objects.Data;
using FessooFramework.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models
{
    /// <summary>   A flow instance parameters. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

    public class FlowInstanceParameters : EntityObject
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

        /// <summary>   Gets or sets the current state.
        ///             Текущее состояние объекта </summary>
        ///
        /// <value> The current state. </value>

        public int CurrentState { get; set; }

        /// <summary>   Gets or sets the state of the flow instance parameters.
        ///              Текущее состояние объекта в формате Enum</summary>
        ///
        /// <value> The flow instance parameters state. </value>

        public FlowInstanceParametersState CurrentStateEnum
        {
            get => EnumHelper.GetValue<FlowInstanceParametersState>(CurrentState);
            set => CurrentState = (int)value;
        }
    }
}
