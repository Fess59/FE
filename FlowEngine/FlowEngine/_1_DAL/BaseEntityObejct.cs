using FlowEngineV1._2_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1._1_DAL
{
    /// <summary>
    /// The <see cref="FlowEngineV1._1_DAL"/> namespace contains classes for ....
    /// </summary>


    /// <summary><para>  Базовая модель Entity - все модели базы данных в системе, наследуются от этого класса </para>
    ///             <para>- Реализована система архивирования изменений модели, с помощью события SaveChanges </para>
    ///            <para> - Добавлен единый признак удаления объекта в базе </para></summary>
    ///
    /// <remarks>   AM Kozhevnikov, 11.01.2018. 
    ///             TODO добавить настройку SaveChages в Bootstrapper системы и её настройки </remarks>
    public class BaseEntityObject : BaseObject
    {
        #region Static

        /// <summary>   Возможность подписаться на систему архиварования - к примеру вывод информации или её хранение. </summary>
        ///
        /// <value> The save changes. </value>

        public static Action<ChangeHistory> SaveChanges { get; set; }
        #endregion
        #region Property

        /// <summary>   Gets or sets a value indicating whether this object has removed. </summary>
        ///
        /// <value> True if this object has removed, false if not. </value>

        public bool HasRemoved { get; set; }

        /// <summary>   Gets or sets the identifier of the last change. </summary>
        ///
        /// <value> The identifier of the last change. </value>

        public Guid? LastChangeId { get; set; }
        #endregion
        #region Constructor

        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 11.01.2018. </remarks>

        public BaseEntityObject() : base()
        {
            Change("Create");
        }
        #endregion
        #region Public methods
        /// <summary>   Create and send <see ref="<ChangeHistory>"> model </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 11.01.2018. </remarks>
        ///
        /// <param name="comment">  (Optional) The comment. </param>
        /// <param name="userId">   (Optional) Identifier for the user. </param>
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
