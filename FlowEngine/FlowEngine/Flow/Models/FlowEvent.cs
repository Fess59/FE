using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Точка входу в систему Flow
    /// </summary>
    public class FlowEvent : FlowObject
    {
        public static FlowEvent New(string name, string uid, string description = "")
        {
            return new FlowEvent()
            {
                Name = name,
                UID = uid,
                Description = description
            };
        }
    }
}
