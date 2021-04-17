using System;
using System.Threading;

namespace code.Threadings
{
    /*Cancela - guarda a passagem de threads    
    similiar ao lock, só pode passar um de cada vez
    AutoResetEvent - fecha a cancela assim que um passa tento abrir-entro-fecho
    ManualResetEvent - não fecha a cancela automaticamente abro-passa uma galera - fecho
    */
    public class AutoEManualResetEventSample
    {
        public static void Run()
        {
            var cancela = new Cancela();

            for(int i = 0; i < 5; i++)
            {
                var thread = new Thread(() => Execute(cancela));
                thread.Name = $"Thread #{i}";
                thread.Start();
            }

            new Thread(() => RunGuarda(cancela)).Start();
        }

        private static void Execute(Cancela cancela)
        {
            while(true)
            {
                cancela.Passar(Thread.CurrentThread.Name);
                Thread.Sleep(300);
                // cancela.Abrir(); autoresetevent
                cancela.Fechar(); //Fecha a cancela
            }
        }

        private static void RunGuarda(Cancela cancela)
        {
            while(true)
            {
                Console.WriteLine("#Guarda abrindo cancela#\n\n");
                cancela.Abrir();
                Thread.Sleep(3000);
            }
        }
    } 
}