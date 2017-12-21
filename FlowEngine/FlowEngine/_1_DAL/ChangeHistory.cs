using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Модель фиксации любого изменения для любого объекта в базе
    /// </summary>
    public class ChangeHistory : BaseEntityObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid ObjectId { get; set; }
        /// <summary>
        /// Тип объекта
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// Пользователь совершивший изменение
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Комментарий объекта
        /// </summary>
        public string Comment { get; set; }

        public static ChangeHistory New(Guid objectId, string objectType, Guid? userId, string comment)
        {
            if (objectId == Guid.Empty)
                throw new NullReferenceException("ChangeHistory.Create ObjectId не может Empty");
            return new ChangeHistory()
            {
                ObjectId = objectId,
                ObjectType = objectType,
                UserId = userId,
                Comment = comment
            };
        }
    }
}
