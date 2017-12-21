using FlowEngine.Tools.Container;
using FlowEngineV1.Flow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Flow
{
    public static class FakeApplicationData
    {
        //Core DB
        public static ApplicationCard Application = new ApplicationCard() { Name = "BEST Application" };
        public static List<FlowEvent> EventList = new List<FlowEvent>();

        //Memory data
        public static FlowEventContainer EventContainer { get; set; }


        public static List<FlowActivity> ActivityList = new List<FlowActivity>();
        public static List<FlowProperty> PropertyList = new List<FlowProperty>();
        public static List<FlowActivityCondition> ActivityConditionList = new List<FlowActivityCondition>();
        public static List<FlowInstance> FlowInstances = new List<FlowInstance>();
 
        static FakeApplicationData()
        {
            Init();
        }
        private static void Init()
        {
            //Эвент 1
            //Список эвентов в базе
            var eventFirst = FlowEvent.New(Events.FirstEvent.ToString(), Events.FirstEvent.ToString());
            EventList.Add(eventFirst);
            EventContainer = FlowEventContainer.New(EventList);


            //Создаём дата сет для эвента
            var propertyIterationCount = FlowProperty.New(Application.Id, "Количество итераций", FlowPropertyType.Int32);
            PropertyList.Add(propertyIterationCount);

            //Создаём активности
            var activityStage0 = FlowActivity.NewStart(Application.Id, eventFirst.Id, "Stage 0 Create");
            var activityStage1 = FlowActivity.New(Application.Id, eventFirst.Id, 1, "Stage 1");
            var activityStage2 = FlowActivity.New(Application.Id, eventFirst.Id, 2, "Stage 2");
            var activityStage3 = FlowActivity.New(Application.Id, eventFirst.Id, 3, "Stage 3");
            var activityStage4 = FlowActivity.New(Application.Id, eventFirst.Id, 4, "Stage 4");
            var activityStage5 = FlowActivity.NewEnd(Application.Id, eventFirst.Id, 5, "Stage 5 End");
            ActivityList.Add(activityStage0);
            ActivityList.Add(activityStage1);
            ActivityList.Add(activityStage2);
            ActivityList.Add(activityStage3);
            ActivityList.Add(activityStage4);
            ActivityList.Add(activityStage5);

            //Создаём сравнения для активностей
            ActivityConditionList.Add(FlowActivityCondition.New(Application.Id, activityStage1.Id, propertyIterationCount.Id,  2.ToString()));
            ActivityConditionList.Add(FlowActivityCondition.New(Application.Id, activityStage2.Id, propertyIterationCount.Id, 4.ToString()));
            ActivityConditionList.Add(FlowActivityCondition.New(Application.Id, activityStage3.Id, propertyIterationCount.Id,  6.ToString()));
            ActivityConditionList.Add(FlowActivityCondition.New(Application.Id, activityStage4.Id, propertyIterationCount.Id,  8.ToString()));
            ActivityConditionList.Add(FlowActivityCondition.New(Application.Id, activityStage5.Id, propertyIterationCount.Id,  9.ToString()));

            //Создаём последовательность экшенов после успешного выполнения
        }

    }

    public enum Events
    {
        FirstEvent = 0,
        SecondEvent = 1
    }
}
