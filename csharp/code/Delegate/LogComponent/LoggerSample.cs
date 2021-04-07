
using System;

namespace code.Delegates
{
    public class LoggerSample
    {
        public static void Run()
        {
            var file = new FileLogger("./log.txt"); //Adiciona filelogger ao Logger
            Logger.LogMessage(Severity.Critical, nameof(LoggerSample), "Falha critica, chamar os bombeiros no log");        
            Logger.WriteMessage += ConsoleLogger.LogToConsole; //Adicionando mais um meio de log                        
            Logger.LogMessage(Severity.Critical, nameof(LoggerSample), "Falha critica, chamar os bombeiros no campos log console e no file console!");
            file.DetachLog(); //Removendo o log em arquivo
        }
    }
}
