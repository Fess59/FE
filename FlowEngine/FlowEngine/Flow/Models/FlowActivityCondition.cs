using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Описание операции сравнения  тип сравнения значения и финальный
    /// </summary>
    public class FlowActivityCondition : FlowObject
    {
        public Guid ActivityId { get; set; }

        #region Compare group - группа объединяется по приоритету и типу, если с одним и тем же приоритетом будет доступно несколько разных типов. Выполнить по очередности типа - все AND=0 => все OR =1 => и т.д.
        /// <summary>
        /// Приоритет выполнения
        /// </summary>
        public int GroupPriority { get; set; }
        /// <summary>
        /// Тип сравнения AND, OR и т.д.
        /// </summary>
        public ActivityConditionGroupType GroupConditionType { get; set; }
        #endregion
        #region Property compare
        /// <summary>
        /// Тип сравнения =, >, < и т.д.
        /// </summary>
        public ActivityConditionPropertyType PropertyConditionType { get; set; }
        /// <summary>
        /// Занчение с которым сравниваем
        /// </summary>
        public string PropertyValue { get; set; }
        /// <summary>
        /// Идентификатор указывающий на тип объекта для сравнения
        /// </summary>
        public Guid PropertyId { get; set; }
        #endregion
        public static FlowActivityCondition New(Guid applicationId, Guid activityId, Guid propertyId, string propertyValue, ActivityConditionPropertyType propertyConditionType = ActivityConditionPropertyType.EQUALS, int groupPriority = 1000, ActivityConditionGroupType groupType = ActivityConditionGroupType.AND, string name = "", string description = "")
        {
            return new FlowActivityCondition()
            {
                ApplicationId = applicationId,
                PropertyId = propertyId,
                PropertyValue = propertyValue,
                PropertyConditionType = propertyConditionType,
                GroupPriority = groupPriority,
                GroupConditionType = groupType,
                Name = name,
                Description = description,
                ActivityId= activityId,
            };
        }
    }
    public enum ActivityConditionPropertyType
    {
        EQUALS = 0,

    }
    public enum ActivityConditionGroupType
    {
        AND = 0,
        OR = 1,

    }
}
