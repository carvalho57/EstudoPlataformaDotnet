
using System;

namespace code.Delegates
{
    public static class ConsoleLogger
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }
    }
}
