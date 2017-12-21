using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    public class FlowActivity : FlowObject
    {
        public Guid EventId { get; set; }
        public FlowActivityType ActivityType { get; set; }
        public int Stage { get; set; }
        public int StageNext { get; set; }
        public static FlowActivity NewStart(Guid applicationId, Guid eventId, string name)
        {
            return New(applicationId, eventId, 0, name, FlowActivityType.Start);
        }
        public static FlowActivity NewEnd(Guid applicationId, Guid eventId, int stageNow, string name)
        {
            return New(applicationId, eventId, stageNow, name, FlowActivityType.End);
        }
        public static FlowActivity New(Guid applicationId, Guid eventId, int stageNow, string name, FlowActivityType activityType = FlowActivityType.Flow)
        {
            return new FlowActivity()
            {
                ApplicationId = applicationId,
                EventId = eventId,
                ActivityType = activityType,
                Stage = stageNow,
                StageNext = stageNow + 1,
                Name = name
            };
        }
    }

    public enum FlowActivityType
    {
        Flow = 0,
        FlowMessage = 1,
        Gate = 2,
        Start = 3,
        End = 4
    }
}
