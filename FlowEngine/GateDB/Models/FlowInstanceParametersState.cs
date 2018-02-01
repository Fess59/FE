using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.Models
{
    /// <summary>   Values that represent flow instance parameters states.
    ///             Состояние текущего запроса </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

    public enum FlowInstanceParametersState
    {
        [Description("Создан - новая копия не сохранённая в базу данных")]
        Create = 0,
        [Description("Очередь - объект ожидает обработки")]
        Queued = 1,
        [Description("Обработка - объект отправлен на обработку, ожидает подтвержединия")]
        Processing = 2,
        [Description("Откат - в процессе обаботки объекта Processing, что-то пошло нет так, обработка была остановлена. Требуется вернуть объект в изначальное состояние с использованием внешенего источника")]
        Roolback = 3,
        [Description("Приостановлена обработка - после нескольких попыток обработки она была остановлена. Так же такое состояние может быть у объектов поток которых в данный момент в состоянии миграции")]
        Suspended = 4,
        [Description("Успешно заверешено - объект обработан и готов к удалению")]
        Complete = 5
    }
}
