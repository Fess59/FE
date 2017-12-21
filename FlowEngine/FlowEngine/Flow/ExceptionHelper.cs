using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase(string className, string methodName, string comment) : base($"{className}.{methodName} {comment}") { }
    }
    public class ExceptionFlowIOContainer : ExceptionBase
    {
        public ExceptionFlowIOContainer(string methodName, string comment) : base("ContainerBase", methodName, comment) { }
    }
}
