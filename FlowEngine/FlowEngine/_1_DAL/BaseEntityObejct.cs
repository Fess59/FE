using FlowEngineV1._2_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1._1_DAL
{
    public class BaseEntityObject : BaseObject
    {
        #region Static
        public static Action<ChangeHistory> SaveChanges { get; set; }
        #endregion
        #region Property
        /// <summary>
        /// Объект был удален
        /// </summary>
        public bool HasRemoved { get; set; }
        /// <summary>
        /// Идентификатор последнего изменения
        /// </summary>
        public Guid? LastChangeId { get; set; }
        #endregion
        #region Constructor
        public BaseEntityObject() : base()
        {
            Change("Create");
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Формирует и пытается отправить модель изменения данных, для успеха требуется подвзяать BaseEntityObejct.SaveChanges
        /// Добавить 
        /// </summary>
        /// <param name="comment">Комментарий к изменению</param>
        /// <param name="userId">Пользователь совершивший изменение</param>
        public void Change(string comment = "Change", Guid? userId = null)
        {
            try
            {
                SaveChanges?.Invoke(ChangeHistory.New(Id, GetType().Name, userId, comment));
            }
            catch (Exception ex)
            {
                Logger.SendMessage(ex.ToString());
            }
        }
        public void Remove()
        {
            Change("Remove");
        }
        #endregion

    }
}
