using System;
using System.Linq;
using System.Threading;

namespace code.Threadings
{
    public class MultiThreadingSample
    {
        public static void Run()
        {
            // var thread = new Thread(_ => Console.WriteLine("Execute"));
            // thread.Start();
            CreatingThread();
            // JoinThread();
        }

        public static void CreatingThread()
        {
            var thread = new Thread(new ThreadStart(Execute));
            Thread.CurrentThread.Name = "Main";
            thread.Name = "Thread";
            thread.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Continue to execute Creating Thread {i}");
                Thread.Sleep(0);
            }
        }
        public static void JoinThread()
        {
            var thread = new Thread(new ThreadStart(Execute));
            thread.Start();
            thread.Join(); //Aguarda o proce
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Continue to execute Creating Thread {i}");
            }
        }
        public static void Execute()
        {
            foreach (var i in Enumerable.Range(1, 20))
            {
                Console.WriteLine($"{i} - {Thread.CurrentThread.Name}");
                Thread.Sleep(200);
            }
        }
    }
}