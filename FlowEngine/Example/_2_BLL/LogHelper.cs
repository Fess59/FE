using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public static class LogHelper
    {
        public static void ExecuteAsync(Action action)
        {
            Task.Factory.StartNew(() => Execute(action));
        }
        public static void Execute(Action action)
        {
            try
            {
                if (action == null)
                    throw new NullReferenceException("LogHelper.Execute - Параметр action не может быть null");
                action.Invoke();
            }
            catch (Exception ex)
            {
                SendException(ex.ToString());
            }
        }
        public static void SendMessage(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("o")}] {message}");
        }
        static void SendException(string message)
        {
            SendMessage(message);
        }
    }
}
