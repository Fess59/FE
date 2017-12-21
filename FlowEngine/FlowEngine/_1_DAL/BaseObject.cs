using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    public class BaseObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Дата создания объекта
        /// </summary>
        public DateTime CreateDate { get; private set; }
        public BaseObject()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
}
