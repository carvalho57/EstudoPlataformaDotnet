using System;
using System.Collections.Generic;
using System.Threading;

namespace code.Threadings
{
    public class ProduceConsumerSample
    {
        private static Random random = new Random();
        public static void Run()
        {
            Console.Write("Informe a quantidade de consumidores:");
            int NumConsumidores = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe a quantidade de produtores:");
            int NumProdutores = Convert.ToInt32(Console.ReadLine());


            var buffer = new Buffer();
            for (int i = 0; i < NumConsumidores; i++)
            {
                new Thread(() => Consumir(buffer)).Start();
            }

            for (int i = 0; i < NumProdutores; i++)
            {
                new Thread(() => Produzir(buffer)).Start();
            }
        }
        private static void Consumir(Buffer buffer)
        {
            while (true)
            {
                int e = buffer.Consumir();
                buffer.Mostrar();
                Thread.Sleep(1000);
            }
        }

        private static void Produzir(Buffer buffer)
        {
            while (true)
            {
                buffer.Produzir(random.Next(10));
                buffer.Mostrar();
                Thread.Sleep(1000);
            }
        }
    }

    public class Buffer
    {
        const int Max = 10;
        private readonly object sync = new object();
        Queue<int> lista = new Queue<int>();
        

        public void Produzir(int n)
        {
            lock (sync)
            {
                while (lista.Count == Max)
                    Monitor.Wait(sync);//Bloqueia a thread se não tiver como produzir

                lista.Enqueue(n);
                Monitor.PulseAll(sync);
            }
        }

        public int Consumir()
        {
            lock (sync)
            {
                while (lista.Count == 0) //Bloqueia se não tiver elementos
                    Monitor.Wait(sync);

                var item = lista.Dequeue();

                Monitor.PulseAll(sync);
                return item;
            }
        }

        public void Mostrar()
        {
            lock (sync)
            {
                Console.Write("=> ");
                foreach (int item in lista)
                    Console.Write($"{item} ");
                Console.WriteLine();
            }
        }
    }

}