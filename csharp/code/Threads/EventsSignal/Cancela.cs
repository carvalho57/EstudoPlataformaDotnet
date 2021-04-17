using System;
using System.Threading;

namespace code.Threadings
{
    public class Cancela
    {
        // AutoResetEvent resetEvent = new AutoResetEvent(true);
        ManualResetEventSlim resetEvent = new ManualResetEventSlim(false);
        public void Abrir()
        {
            resetEvent.Set();
        }

        public void Fechar()
        {
            resetEvent.Reset();
        }
        public void Passar(string name)
        {
            Console.WriteLine($"WaitONe {name} ");
            // resetEvent.WaitOne();            
            resetEvent.Wait();
            Console.WriteLine($"{name} passando pela cancela");                                    
        }
    }
}