using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Containers.ElementsFlowPropertyType;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Containers
{
    public class ContainerFlowPropertyType : IOContainerExecute<ElementFlowPropertyType, FlowPropertyType, ParamsFlowPropertyType>
    {
        #region Methods
        /// <summary>   Executes. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 10.01.2018. </remarks>
        ///
        /// <param name="newValue">         The new value. </param>
        /// <param name="oldValue">         The old value. </param>
        /// <param name="conditionType">    Type of the condition. </param>
        /// <param name="propertyType">     Type of the property. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public bool Execute(string newValue, string oldValue, ActivityConditionPropertyType conditionType, FlowPropertyType propertyType)
        {
            return Execute(ParamsFlowPropertyType.New(newValue, oldValue, conditionType, propertyType));
        }
        #endregion
        #region Static methods

        /// <summary>   Gets the new. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 10.01.2018. </remarks>
        ///
        /// <returns>   A ContainerFlowPropertyType. </returns>

        public static ContainerFlowPropertyType New()
        {
            var result = new ContainerFlowPropertyType();
            result.Add(new STRING());
            result.Add(new INT32());
            return result;
        }
        #endregion
    }
}
