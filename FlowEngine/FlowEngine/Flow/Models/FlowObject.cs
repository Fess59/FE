using FlowEngineV1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow.Models
{
    /// <summary>
    /// Базовый объект Flow системы
    /// </summary>
    public class FlowObject : BaseEntityObject
    {
        /// <summary>
        /// Идентификатор приложения вызвавшего данный запрос
        /// </summary>
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// Уникальный ключ идентификации в системе - закриптованная строка с помощью SHA512(Application.Name + "_" +  FlowEvent.Name)
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// Необязательное поле наименования
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Необязательное поле описания
        /// </summary>
        public string Description { get; set; }
        public virtual void SetUID(string uid)
        {
            UID = Cryptography.StringToSha256String(uid);
        }
    }
}
