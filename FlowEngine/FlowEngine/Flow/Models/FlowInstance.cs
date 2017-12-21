using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Инстация запроса отправленного на сервер
    /// </summary>
    public class FlowInstance : FlowObject
    {
        public Guid EventId { get; set; }
        public string EventUID { get; set; }
        public int Stage { get; set; }
        public bool Complete { get; set; }
        public string Value { get; set; }

        public static FlowInstance New(string eventUID, int value)
        {
            return New(eventUID, value.ToString());
        }
        public static FlowInstance New(string eventUID, string value)
        {
            return new FlowInstance()
            {
                EventUID = eventUID,
                Stage = 0,
                Value = value
            };
        }
    }
}
