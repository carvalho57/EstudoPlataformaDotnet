using System;
using System.Threading;
namespace code.Threadings
{
    public static class MonitorSample
    {
        private static object sync = new object();
        public static void Run()
        {
            var counter = new Counter();

            for (int i = 0; i < 10; i++)
            {
                new Thread(() => Execute(counter)).Start();
            }
            Console.WriteLine($"O valor final do contador é : {counter.Count}");
        }
        public static void Execute(Counter counter)
        {
            bool locktaken = false;

            try
            {
                Monitor.Enter(sync, ref locktaken); // obtem lock
                counter.Increment();
                Console.WriteLine($"{counter.Count}");
            }
            finally
            {
                if (locktaken)
                    Monitor.Exit(sync); //libera lock
            }
        }
        public static void ExecuteWithouLock(Counter counter)
        {
            counter.Increment();
            Console.WriteLine($"Increment Counter: {counter.Count}");
        }
    }
}