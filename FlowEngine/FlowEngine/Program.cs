using FlowEngineV1.Flow;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowEngineV1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Создание всей структуры из базы на лету - контейнер с эвентами, активностями и прочим
            //2. API всей системы свести к нескольким методам
            //3. Автоматическая публикация службы для приложения
            //4. Монетизация - общий сервер бесплатный, облако или своя копия платная 
            //5. Сохранение эвентов + миграция + отложенное выполнение на время редактирования и пуша запроса
            //6. Хранение полной истории измениний флов с привязкой к пользователю
            //7. Таблица ПРИЛОЖЕНИЕ главная, к ней привязаны пользователи, лицензии и эвенты
            //8. Аналог callback'a на службу клиента по завершению задачи или возможно настройка рассылки
            //9. Для каждого Application создавать службу и регистрировать название на общем сервере - сервер нужен что бы получить имя службы и ссылку, далее запускается инстанция которая висит многого, и к которой обращаются с указанным Id приложения - так же. В инстанции храним данные о приложении и его флов карту
            //10. Авто генерация API - одна служба на приложение, мб на другом сервере
            //11. Хранить только определённое количество ошибок - 5-10, дополнительно за бабки
            //12. Аналитика состояний для FlowInstance - Создание, Постановка в очередь, Запуск, Заврешение, Тайминг по каждому событию внутри события(сравнение)

            //Визуализация и плюшки:
            //1. Статистика запросов + время выплонения + ошибки + рекомендации
            //а. Аналитика - узкие места, нагрузки и т.д.
            //б. Статистика запросов - количество и объемы
            //в. Агрегатор ошибок
            //г. Рекоменданции - возможность настройки по департаментам и другим секциям 
            //2. Редактор запросов
            //3. Система прав и доступов
            //4. Дерево и структура процессов компании +группы по дирекция и департаментам
            //5. Почтовый сервис построенный полностью на Flow движке

            //Презентация:
            //1. Пример готового сервиса
            //2. Пример работы подразделения
            //3. Пример работы компании и подразделений - желательно с WIKI и шаблонами визуализации для групп сотрудников

            //var firstInstance = new FlowInstance() { UID = "1", Stage = 0 };
            //FakeApplicationData.FlowInstances.Add(firstInstance);
            //while (!firstInstance.Complete)
            //{
            //    Thread.Sleep(1000);
            //    FakeFlow.FirstEvent(firstInstance);
            //    firstInstance.Value += 1;
            //}
            var firstEvent = FakeApplicationData.EventList.FirstOrDefault(q => q.Name == Events.FirstEvent.ToString());
            var secondInstance = FlowInstance.New(firstEvent.Id, 0);
            while (!secondInstance.Complete)
            {
                Thread.Sleep(1000);
                FakeFlowSystem.Execute(secondInstance);
                secondInstance.Value = (int.Parse(secondInstance.Value) + 1).ToString();
            }
            FakeApplicationData.FlowInstances.Add(secondInstance);
            Logger.SendMessage("Complite");
            Console.ReadLine();
        }

        static void DataSystemBinding()
        {
            BaseEntityObject.SaveChanges += changeModel => {/* Save change history here*/ };
        }


    }
}
