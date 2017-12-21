using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1
{
    //public static class FakeFlow
    //{
    //    public static void FirstEvent(FlowInstance instance)
    //    {
    //        try
    //        {
    //            var text = "Выполнена обработка инстации";
    //            switch (instance.Stage)
    //            {
    //                case 0:
    //                    text += Stage1(instance);
    //                    break;
    //                case 1:
    //                    text += Stage2(instance);
    //                    break;
    //                case 2:
    //                    text += Stage3(instance);
    //                    break;
    //                case 3:
    //                    text += Stage4(instance);
    //                    break;
    //                case 4:
    //                    text += Stage5(instance);
    //                    break;
    //                default:
    //                     text += "Выполнена обработка инстации - ошибка шаг не реализован и не является Event'ом завершения" ;
    //                    break;
    //            }
    //            Logger.SendMessage(text);
    //        }
    //        catch (Exception ex)
    //        {
    //            Logger.SendMessage(ex.ToString());
    //        }
    //    }
    //    public static string Stage1(FlowInstance instance)
    //    {
    //        var stageNumber = 1;
    //        var notComplete = false;
    //        var result = $"Stage{stageNumber}:{Environment.NewLine}";
    //        //Вычисляем условия по очереди и один раз - в движке условия могут проверять далеко далеко на далеких серверах
    //        var Condition1 = instance.Value > 0;
    //        if (!notComplete)
    //        {
    //            if (Condition1)
    //                result += $"Условие 1 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 1 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (!notComplete)
    //        {
    //            var Condition2 = instance.Value >= 2;
    //            if (Condition2)
    //                result += $"Условие 2 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 2 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (notComplete)
    //        {
    //            result += $"Stage{stageNumber} не выполенено {Environment.NewLine}";
    //        }
    //        else
    //        {
    //            instance.Stage = stageNumber;
    //            result += $"Stage{stageNumber} выполенено {Environment.NewLine}";
    //        }
    //        return result;
    //    }
    //    public static string Stage2(FlowInstance instance)
    //    {
    //        var stageNumber = 2;
    //        var notComplete = false;
    //        var result = $"Stage{stageNumber}:{Environment.NewLine}";

    //        //Вычисляем условия по очереди и один раз - в движке условия могут проверять далеко далеко на далеких серверах
    //        var Condition1 = instance.Value > 0;
    //        if (!notComplete)
    //        {
    //            if (Condition1)
    //                result += $"Условие 1 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 1 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (!notComplete)
    //        {
    //            var Condition2 = instance.Value >= 6;
    //            if (Condition2)
    //                result += $"Условие 2 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 2 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (notComplete)
    //        {
    //            result += $"Stage{stageNumber} не выполенено {Environment.NewLine}";
    //        }
    //        else
    //        {
    //            instance.Stage = stageNumber;
    //            result += $"Stage{stageNumber} выполенено {Environment.NewLine}";
    //        }
    //        return result;
    //    }
    //    public static string Stage3(FlowInstance instance)
    //    {
    //        var stageNumber =3;
    //        var notComplete = false;
    //        var result = $"Stage{stageNumber}:{Environment.NewLine}";

    //        //Вычисляем условия по очереди и один раз - в движке условия могут проверять далеко далеко на далеких серверах
    //        var Condition1 = instance.Value > 0;
    //        if (!notComplete)
    //        {
    //            if (Condition1)
    //                result += $"Условие 1 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 1 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (!notComplete)
    //        {
    //            var Condition2 = instance.Value >= 10;
    //            if (Condition2)
    //                result += $"Условие 2 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 2 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (notComplete)
    //        {
    //            result += $"Stage{stageNumber} не выполенено {Environment.NewLine}";
    //        }
    //        else
    //        {
    //            instance.Stage = stageNumber;
    //            result += $"Stage{stageNumber} выполенено {Environment.NewLine}";
    //        }
    //        return result;
    //    }
    //    public static string Stage4(FlowInstance instance)
    //    {
    //        var stageNumber = 4;
    //        var notComplete = false;
    //        var result = $"Stage{stageNumber}:{Environment.NewLine}";

    //        //Вычисляем условия по очереди и один раз - в движке условия могут проверять далеко далеко на далеких серверах
    //        var Condition1 = instance.Value > 0;
    //        if (!notComplete)
    //        {
    //            if (Condition1)
    //                result += $"Условие 1 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 1 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (!notComplete)
    //        {
    //            var Condition2 = instance.Value >= 10;
    //            if (Condition2)
    //                result += $"Условие 2 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 2 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (notComplete)
    //        {
    //            result += $"Stage{stageNumber} не выполенено {Environment.NewLine}";
    //        }
    //        else
    //        {
    //            instance.Stage = stageNumber;
    //            result += $"Stage{stageNumber} выполенено {Environment.NewLine}";
    //        }
    //        return result;
    //    }
    //    public static string Stage5(FlowInstance instance)
    //    {
    //        var stageNumber = 5;
    //        var notComplete = false;
    //        var isFinally = true;
    //        var result = $"Stage{stageNumber}:{Environment.NewLine}";

    //        //Вычисляем условия по очереди и один раз - в движке условия могут проверять далеко далеко на далеких серверах
    //        var Condition1 = instance.Value > 0;
    //        if (!notComplete)
    //        {
    //            if (Condition1)
    //                result += $"Условие 1 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 1 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (!notComplete)
    //        {
    //            var Condition2 = instance.Value >= 10;
    //            if (Condition2)
    //                result += $"Условие 2 выполенено {Environment.NewLine}";
    //            else
    //            {
    //                result += $"Условие 2 не выполенено {Environment.NewLine}";
    //                notComplete = true;
    //            }
    //        }

    //        if (notComplete)
    //        {
    //            result += $"Stage{stageNumber} не выполенено {Environment.NewLine}";
    //        }
    //        else
    //        {
    //            instance.Stage = stageNumber;
    //            result += $"Stage{stageNumber} выполенено {Environment.NewLine}";
    //        }
    //        if (isFinally)
    //        {
    //            instance.Complete = true;
    //            result += $"Event complited{Environment.NewLine}";
    //        }
    //        return result;
    //    }
    //}
}
