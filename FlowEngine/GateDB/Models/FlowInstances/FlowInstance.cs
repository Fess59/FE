using FessooFramework.Objects.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models.FlowInstances
{
    /// <summary>   A flow instance. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

    public class FlowInstance : EntityObjectALM<FlowInstance, FlowInstanceState>
    {
        #region Property
        /// <summary>   Gets or sets the token.
        ///             Уникальный токен приложения, генерируется из личного кабинета </summary>
        ///
        /// <value> The token. </value>
        public string Token { get; set; }

        /// <summary>   Gets or sets the flow UID.
        ///             Схема Flow в которой будет выполенен запрос </summary>
        ///
        /// <value> The flow UID. </value>

        public string FlowUID { get; set; }

        /// <summary>   Gets or sets the object UID.
        ///             Идентификатор объекта для которого произошёл шаг жизненного цикла </summary>
        ///
        /// <value> The object UID. </value>

        public string ObjectUID { get; set; }
        #endregion
        #region Methods 

        /// <summary>   New FlowInstance. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 08.02.2018. </remarks>
        ///
        /// <param name="token">        The token. </param>
        /// <param name="flowUID">      The flow UID. </param>
        /// <param name="objectUID">    The object UID. </param>
        ///
        /// <returns>   A FlowInstance. </returns>

        public static FlowInstance New(string token, string flowUID, string objectUID)
        {
            return new FlowInstance()
            {
                Token = token,
                FlowUID = flowUID,
                ObjectUID = objectUID,
            };
        }
        #endregion
        #region ALM
        protected override IEnumerable<EntityObjectALMConfiguration<FlowInstance, FlowInstanceState>> Configurations => new EntityObjectALMConfiguration<FlowInstance, FlowInstanceState>[] {
            EntityObjectALMConfiguration<FlowInstance, FlowInstanceState>.New(FlowInstanceState.Create,FlowInstanceState.Create,  FlowInstanceHelper.CreateToCreate),
            EntityObjectALMConfiguration<FlowInstance, FlowInstanceState>.New(FlowInstanceState.Create,FlowInstanceState.Await,  FlowInstanceHelper.CreateToAwait),
        };
        protected override IEnumerable<FlowInstanceState> DefaultState => new[] { FlowInstanceState.Error };

        protected override int GetStateValue(FlowInstanceState state)
        {
            return (int)state;
        }
        #endregion
    }
}
