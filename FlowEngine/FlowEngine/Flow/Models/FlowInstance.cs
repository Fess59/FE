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
        public int Stage { get; set; }
        public bool Complete { get; set; }
        public string Value { get; set; }

        public static FlowInstance New(Guid eventId, int value)
        {
            return New(eventId, value.ToString());
        }
        public static FlowInstance New(Guid eventId, string value)
        {
            return new FlowInstance()
            {
                EventId = eventId,
                Stage = 0,
                Value = value
            };
        }
    }
}
