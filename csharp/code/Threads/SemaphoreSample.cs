using System;
using System.Linq;
using System.Threading;

namespace code.Threadings
{
    public class SemaphoreSample
    {
        public static void Run()
        {
            var printers = new Printers();

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() => Execute(printers));
                thread.Name = $"Thread #{i}";
                thread.Start();
            }
        }

        private static void Execute(Printers printers)
        {
            while (true)
            {
                printers.Print(Thread.CurrentThread.Name);
                Thread.Sleep(100);
            }
        }
    }

    public class Printers
    {
        private const int Count = 3;
        private bool[] usedPrinters = new bool[Count];
        private Random random;
        private SemaphoreSlim semaphore; //Apenas em treads e não em processos

        public Printers()
        {
            // semaphore = new SemaphoreSlim(0,Count); // teste
            semaphore = new SemaphoreSlim(Count);
            random = new Random();
        }

        public void Print(string name)
        {
            semaphore.Wait(); //Down - Try - Decrement

            try
            {
                var index = GetPrinter();
                if (index < 0) throw new ApplicationException("");
                Console.WriteLine($"Impressora {index} iniciando impressão da thread {name}");
                Thread.Sleep(random.Next(3500));
                Console.WriteLine($"Impressora {index} finalizando ....");
                usedPrinters[index] = false;
            }
            finally
            {
                semaphore.Release(); //Up (Increment)
            }
        }

        private int GetPrinter()
        {
            for (int i = 0; i < usedPrinters.Length; i++)
            {
                if (!usedPrinters[i])
                {
                    usedPrinters[i] = true;
                    return i;
                }
            }
            return -1;
        }
    }
}