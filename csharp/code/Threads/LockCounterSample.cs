using System;
using System.Threading;
namespace code.Threadings
{
    public class Counter
    {
        public int Count { get; private set; }
        public void Increment() => Count++;
    }

    public static class LockCounter
    {
        private static object sync = new object();

        private static CountdownEvent countdownEvent;
        public static void Run()
        {
            var counter = new Counter();
            var numberOfThreads = 10;
            countdownEvent = new CountdownEvent(numberOfThreads);

            for (int i = 0; i < numberOfThreads; i++)
            {
                // new Thread(() => ExecuteWithouLock(counter, countdownEvent)).Start();
                // new Thread(() => Execute(counter, countdownEvent)).Start();
                // new Thread(() => ExecuteMonitor(counter, countdownEvent)).Start();
            }

            countdownEvent.Wait();
            Console.WriteLine($"O valor final do contador é : {counter.Count}");
        }
        public static void ExecuteMonitor(Counter counter, CountdownEvent countdown)
        {
            bool locktaken = false; //lock foi obtido

            try
            {
                Monitor.Enter(sync, ref locktaken);
                counter.Increment();
                Console.WriteLine($"{counter.Count}");
            }
            finally
            {
                if (locktaken) {
                    Monitor.Exit(sync);
                    countdown.Signal();
                }
            }
        }
        public static void Execute(Counter counter, CountdownEvent countdown)
        {
            lock (sync) //Gera chamadas para a classe monitor
            {
                counter.Increment();
                Console.WriteLine($"Increment Counter: {counter.Count}");
            }
            countdown.Signal();
        }

        public static void ExecuteWithouLock(Counter counter, CountdownEvent countdown)
        {            
            counter.Increment();
            Console.WriteLine($"Increment Counter: {counter.Count}");
            countdown.Signal();
        }
    }
}