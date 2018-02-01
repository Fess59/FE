using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models
{
    /// <summary>   A flow instance. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

    public class FlowInstance : EntityObject
    {
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
    }
}
