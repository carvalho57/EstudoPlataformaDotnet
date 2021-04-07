
using System;

namespace code.Delegates
{
    public enum Severity
    {
        Verbose,
        Trace,
        Information,
        Warning,
        Error,
        Critical
    }
    public static class Logger
    {
        public static Action<string> WriteMessage;
        public static Severity LogLevel { get; set; } = Severity.Warning;

        public static void LogMessage(string message)
        {
            WriteMessage(message);
        }
        public static void LogMessage(Severity severity, string component, string message)
        {
            if (severity >= LogLevel)
            {
                var output = $"{DateTime.Now}\t{severity}\t{component}\t{message}";                
                if (WriteMessage != null) WriteMessage(output);
            }
        }


    }
}
