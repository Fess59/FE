using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1._2_BLL
{
    public static class Logger
    {
        public static void SendMessage(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("o")}] " + message);
        }
    }
}
