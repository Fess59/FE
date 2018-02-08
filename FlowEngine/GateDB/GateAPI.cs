using FessooFramework.Tools.Helpers;
using GateDB.Models;
using GateDB.Models.FlowInstances;
using GateDB.Models.FlowInstancesParameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB
{
    /// <summary>   A gate API.
    ///             Логика взаимодействия с Gate </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 07.02.2018. </remarks>

    public static class GateAPI
    {
        #region Model
        /// <summary>   A flow query. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 08.02.2018. </remarks>
        public struct FlowQuery
        {
            public FlowInstance Instance { get; set; }
            public string ObjectState { get; set; }
            public string ObjectParameters { get; set; }
            public static FlowQuery New(string token, string flowUID, string objectUID, string objectState, string objectParameters)
            {
                return new FlowQuery()
                {
                    Instance = FlowInstance.New(token, flowUID, objectUID),
                    ObjectState = objectState,
                    ObjectParameters = objectParameters
                };
            }
        }
        #endregion
        #region Add
        /// <summary>
        ///     Add an instance. Предназначен для приёма данных с внешнених источников - самая
        ///     нагруженная точка входа в систему.
        /// </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 08.02.2018. </remarks>
        ///
        /// <param name="token">        The token. </param>
        /// <param name="flowUID">      The flow UID. </param>
        /// <param name="objectUID">    The object UID. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public static bool Add(string token, string flowUID, string objectUID, string objectState, string objectParameters)
        {
            var query = FlowQuery.New(token, flowUID, objectUID, objectState, objectParameters);
            return Add(query);
        }
        /// <summary>
        ///     Add an instance. Предназначен для приёма данных с внешнених источников - самая
        ///     нагруженная точка входа в систему.
        /// </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 08.02.2018. </remarks>
        ///
        /// <param name="instance"> The instance. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        internal static bool Add(FlowQuery instance)
        {
            return AddRange(new[] { instance });
        }
        /// <summary>   Adds an instance.
        ///             Предназначен для приёма данных с внешнених источников - самая нагруженная точка входа в систему </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 07.02.2018. </remarks>
        ///
        /// <param name="instances">    The instances. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public static bool AddRange(IEnumerable<FlowQuery> instances)
        {
            var result = false;
            DCT.Execute(c =>
            {
                var instancesGroup = instances.GroupBy(q=>new { q.Instance.Token, q.Instance.FlowUID, q.Instance.ObjectUID });
                foreach (var instanceGroup in instancesGroup)
                {
                    var instance = instanceGroup.FirstOrDefault().Instance;
                    var istId = instance.Id;
                    //Проверяю наличие инстанции потока
                    var entityInstance = c.FlowInstances.FirstOrDefault(q => q.Token == instance.Token && q.FlowUID == instance.FlowUID && q.ObjectUID == instance.ObjectUID && q.State == (int)FlowInstanceState.Await);
                    //Если объект найден все параметры будут прикреплены к нему
                    if (entityInstance == null)
                        instance.StateEnum = FlowInstanceState.Await;
                    else
                        istId = entityInstance.Id;
                 
                    foreach (var query in instanceGroup)
                    {
                        var parameters = FlowInstanceParameters.New(istId, query.ObjectState, query.ObjectParameters);
                        parameters.StateEnum = FlowInstanceParametersState.Queued;
                    }
                }
                c.SaveChanges();
                result = true;
            });
            return result;
        }
        #endregion
        /// <summary>   Gets an instance. Метод ориентирован на внутренню систему, по запросу получает модели на обработку </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 07.02.2018. </remarks>
        ///
        /// <param name="instances">    The instances. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public static IEnumerable<FlowInstance> GetInstance(int count)
        {
            var result = Enumerable.Empty<FlowInstance>();
            DCT.Execute(c =>
            {
                
            });
            return result;
        }

        /// <summary>   Updates the instance described by instances. Внутренний метод системы   </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 07.02.2018. </remarks>
        ///
        /// <param name="instances">    The instances. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public static bool UpdateInstance(IEnumerable<FlowInstance> instances)
        {
            return false;
        }

        /// <summary>   Updates the instance described by instances. Забирает данные для архивирования - локальная интеграция
        ///             Возвращает информацию о моделях, если успех затирает в базе
        ///             Метод использует система аналитики и архивирования</summary>
        ///
        /// <remarks>   AM Kozhevnikov, 07.02.2018. </remarks>
        ///
        /// <param name="instances">    The instances. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public static IEnumerable<FlowInstance> GetArhive()
        {
            return Enumerable.Empty<FlowInstance>();
        }
    }
}
