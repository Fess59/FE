using FlowEngineV1._1_DAL;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1._2_BLL.IOC
{
    /// <summary>   An IOC element. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 11.01.2018. </remarks>

    public class IOCElement: BaseObject
    {
       /// <summary>    Gets or sets the UID. </summary>
       ///
       /// <value>  The UID of IOC element. </value>

       public string UID { get; set; }
    }
}
