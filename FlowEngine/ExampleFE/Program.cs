using FessooFramework.Tools.DCT;
using FessooFramework.Tools.Helpers;
using GateDB;
using GateDB.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GateDB.GateAPI;

namespace ExampleFE
{

    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Current.Run();
            //Кейс полного взаимодействия с системой Flow
            // 
            // Взаимодействие:
            // IN - Внутренние взаимодействие
            // OUT - Внешнее взаимодействие
            // 
            // GeneralSystem - основная система по управлению пользователями и их потоками:
            // 1. OUT Регистрация приложения
            // 2. OUT Регистрация пользователя
            // 3. OUT Подтверждение пользователя
            // 4. OUT Генерация Токена для приложения - если активировано
            // 5. OUT Добавление схемы потока Flow
            // 6. OUT Изменения схемы потока Flow
            // 7. OUT Подключение логического блока
            // 8. OUT Подключение источника данных
            //GateSystem - система управления и формирования входящих запросов:
            // 1. OUT Получение входящих запросов
            // 2. IN.HUB Отправка запросов на обработку в Hub - Hub забирает из сам
            // 3. IN.HUB Получение подтверждения обработки запросов - Получаем из Hub'a
            // 4. IN.ANALITICS Архивация отработанных запросов - ANALITICS

            //Gate_1_Clear(500);
            GateDB.DCT.Execute(c => Gate_1_(500));
            //HubSystem - система управления распределения запросов для дальнейшей обработки
            // 1. IN Забираем и провяем запросы с Gate. По итогу фиксируюем на Gate факт забора данных
            // 2. IN Формируем листы запросов и отправляем на обработку
            // и т.д.


            //GateAPI.AddInstances
            Console.Read();
        }
        #region GateSystem
        //GateSystem - система управления и формирования входящих запросов:
        // 1. OUT Получение входящих запросов
        static void Gate_1_(int count)
        {
            var countCurrent = 0;
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                var list = new List<FlowQuery>();
                list.Add(FlowQuery.New("1", "testFlow", "testOBJ_1", "1", "t2"));
                list.Add(FlowQuery.New("1", "testFlow", "testOBJ_1", "2", "t3"));
                list.Add(FlowQuery.New("1", "testFlow", "testOBJ_2", "3", "t3"));
                list.Add(FlowQuery.New("1", "testFlow", "testOBJ_2", "4", "t4"));
                GateAPI.AddRange(list);
                countCurrent += 4;
            }
            sw.Stop();

            Console.WriteLine($"FlowInstance add complete. Current count={countCurrent}, elapseed={sw.ElapsedMilliseconds.ToString()}");
        }
        static void Gate_1_Clear(int count)
        {
            var countCurrent = 0;
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < count; i++)
            {
                using (var db = new GateDBContext())
                {
                    var istance = db.FlowInstances.FirstOrDefault(q => q.Token == "1" && q.FlowUID == "testFlow" && q.ObjectUID == "testOBJ_1");
                    var istance2 = db.FlowInstances.FirstOrDefault(q => q.Token == "1" && q.FlowUID == "testFlow" && q.ObjectUID == "testOBJ_2");

                    db.FlowInstanceParameters.Add(new GateDB.Models.FlowInstancesParameters.FlowInstanceParameters() { FlowInstanceId = istance.Id, ObjectState = "1", ObejctProperty = "t2" });
                    db.FlowInstanceParameters.Add(new GateDB.Models.FlowInstancesParameters.FlowInstanceParameters() { FlowInstanceId = istance.Id, ObjectState = "2", ObejctProperty = "t3" });
                    db.FlowInstanceParameters.Add(new GateDB.Models.FlowInstancesParameters.FlowInstanceParameters() { FlowInstanceId = istance2.Id, ObjectState = "2", ObejctProperty = "t3" });
                    db.FlowInstanceParameters.Add(new GateDB.Models.FlowInstancesParameters.FlowInstanceParameters() { FlowInstanceId = istance2.Id, ObjectState = "2", ObejctProperty = "t4" });
                    db.SaveChanges();
                    countCurrent += 4;
                }
            }
            sw.Stop();
            ConsoleHelper.Send("Gate", $"FlowInstance add complete. Current count={countCurrent}, elapseed={sw.ElapsedMilliseconds.ToString()}");
        }
        // 2. IN.HUB Отправка запросов на обработку в Hub - Hub забирает из сам
        // 3. IN.HUB Получение подтверждения обработки запросов - Получаем из Hub'a
        // 4. IN.ANALITICS Архивация отработанных запросов - ANALITICS
        static void Gate_2_()
        {

        }
        static void Gate_3_()
        {

        }
        static void Gate_4_()
        {

        }
        #endregion
    }
}
