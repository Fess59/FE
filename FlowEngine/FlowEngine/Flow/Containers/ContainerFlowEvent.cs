using FlowEngineV1;
using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Containers;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools.Containers
{
    /// <summary>
    /// Контейнер для службы или инстанции FlowEngine
    /// Предназначен для формирования на лету
    /// </summary>
    public class ContainerFlowEvent : IOContainerExecute<ElementFlowEvent, FlowEvent, ParamsFlowElement>
    {
        #region Methods

        /// <summary>   Executes the given instance. </summary>
        /// <remarks>   AM Kozhevnikov, 10.01.2018. </remarks>
        /// <param name="instance"> The instance. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public bool Execute(FlowInstance instance)
        {
            return Execute(ParamsFlowElement.New(instance));
        }
        #endregion
        #region Static methods

        /// <summary>   News the given events. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 10.01.2018. </remarks>
        ///
        /// <param name="events">   The events. </param>
        ///
        /// <returns>   A ContainerFlowEvent. </returns>
        ///  <example>
        /// This sample shows how to call the <see cref="GetZero"/> method.
        /// <code>
        /// class TestClass
        /// {
        ///     static int Main()
        ///     {
        ///         return GetZero();
        ///     }
        /// }
        /// </code>
        /// </example>

        public static ContainerFlowEvent New(IEnumerable<FlowEvent> events)
        {
            var result = new ContainerFlowEvent();
            result.AddRange(events.Select(q => ElementFlowEvent.New(q)));
            return result;
        }
        #endregion


       
    }
}
