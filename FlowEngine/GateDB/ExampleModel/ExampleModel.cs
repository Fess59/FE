using FessooFramework.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateDB.ExampleModel
{
    public class ExampleModel : EntityObject
    {
        public string Description { get; set; }
        public int State { get; set; }
        public ExampleModelState StateEnum
        {
            get => EnumHelper.GetValue<ExampleModelState>(State);
            set => State = (int)value;
        }
    }
}
