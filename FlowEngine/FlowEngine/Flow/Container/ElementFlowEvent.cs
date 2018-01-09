using FlowEngineV1;
using FlowEngineV1.Flow;
using FlowEngineV1.Flow.Container;
using FlowEngineV1.Flow.Models;
using FlowEngineV1.Tools.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngine.Tools.Container
{
    public class ElementFlowEvent : IOCElementExecute<FlowEvent, ParamsFlowElement>
    {
        public ElementFlowEvent(FlowEvent element) : base(element)
        {
        }
        public override string GetUID(FlowEvent element)
        {
            return element.UID;
        }
        public override bool Execute(ParamsFlowElement p)
        {
            var result = false;
            try
            {
                var element = p.Value;
                var logText = $"V={element.Value}";
                if (element.Complete)
                {
                    logText += $" Stage={element.Stage} FlowInstance already complete";
                    Logger.SendMessage(logText);
                    return result;
                }
                var stage = FakeApplicationData.ActivityList.FirstOrDefault(q => q.Stage == element.Stage + 1);
                if (stage == null)
                    throw new NullReferenceException($"При обработке инстанции {element.Id} не смогли найти следующий шаг или финальный метод");
                logText += $" Stage={stage.Stage}";
                //Light realization
                var conditions = FakeApplicationData.ActivityConditionList.Where(q => q.ActivityId == stage.Id);

                var conditionGroups = conditions.GroupBy(q => new { q.ActivityId, q.GroupConditionType, q.GroupPriority });
                if (!conditionGroups.Any())
                    throw new NullReferenceException($"При обработке шагов инстанции возникает ошибка {element.Id}, не удалось найти следующий шаг или финальный метод");
                conditionGroups = conditionGroups.OrderBy(q => q.Key.GroupPriority).ThenBy(q => q.Key.GroupConditionType).ToArray();
                var groupResults = new List<bool>();
                foreach (var group in conditionGroups)
                {
                    var results = new List<bool>();
                    foreach (var condition in group)
                    {
                        var property = FakeApplicationData.PropertyList.FirstOrDefault(q => q.Id == condition.PropertyId);
                        results.Add(FakeApplicationData.ContainerFlowPropertyType.Execute(element.Value, condition.PropertyValue, condition.PropertyConditionType, property.PropertyType));
                    }
                    logText += $" СonditionType={group.Key.GroupConditionType}";
                    result = FakeApplicationData.
                        ContainerConditionGroup.Execute(group.Key.GroupConditionType, results);
                    if (result)
                        return result;
                }
                if (stage.ActivityType == FlowActivityType.End)
                    element.Complete = true;
                logText += $" ConditionCheck = Success";
                Logger.SendMessage(logText);

                element.Stage++;
                result = true;
            }
            catch (Exception ex)
            {
                Logger.SendMessage(ex.ToString());
            }
            return result;
        }
        public static ElementFlowEvent New(FlowEvent obj)
        {
            return new ElementFlowEvent(obj);
        }
    }
}
