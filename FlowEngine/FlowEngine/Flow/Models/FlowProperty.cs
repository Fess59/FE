using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Свойство подключенное к проекту, на базе описания которого генерируеться логика сравнения для активности и марштрутизатора потоков
    /// </summary>
    public class FlowProperty : FlowObject
    {
        public FlowPropertyType PropertyType { get; set; }

        public static FlowProperty New(Guid applicationId, string name, FlowPropertyType propertyType = FlowPropertyType.String, string description = "")
        {
            return new FlowProperty()
            {
                ApplicationId = applicationId,
                PropertyType = propertyType,
                Name = name,
                Description = description
            };
        }
    }

    public enum FlowPropertyType
    {
        String = 0,
        Int32 = 1
    }
}
