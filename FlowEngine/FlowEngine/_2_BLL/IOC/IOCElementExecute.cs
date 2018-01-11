using FlowEngineV1._2_BLL.IOC;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1._2_BLL.IOC
{
    /// <summary>   An IOC element execute. Inherits from <see cref="IOCElement" />. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 11.01.2018. </remarks>
    ///
    /// <typeparam name="TElement"> Type of the element. </typeparam>
    /// <typeparam name="TParam">   Type of the parameter. </typeparam>

    public class IOCElementExecute<TElement, TParam>: IOCElement 
        where TParam : IOCElementExecuteParams
    {
        public TElement Element { get; set; }
        public IOCElementExecute(TElement element)
        {
            Element = element;
            UID = GetUID(element);
        }

        /// <summary>   Gets an UID from IOC element. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 11.01.2018. </remarks>
        ///
        /// <param name="element">  The IOCExecute element. </param>
        ///
        /// <returns>   The UID of IOC element. </returns>

        public virtual string GetUID(TElement element)
        {
            throw new NotImplementedException($"IOCElementExecute {UID}. Метод Execute не реализован");
        }

        /// <summary>   Executes the given parameter. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 11.01.2018. </remarks>
        ///
        /// <param name="parameter">    The parameter. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public virtual bool Execute(TParam parameter)
        {
            throw new NotImplementedException($"IOCElementExecute {UID}. Метод Execute не реализован");
        }
    }
}
