using System;
using System.Threading;
using System.Collections.Generic;

namespace code.Threadings
{
    //     Crie uma aplicação onde 5 threads inserem 10 números randômicos em uma lista, a qual é
    // compartilhada entre as threads.Quando todas terminarem de executar sua tarefa, imprima os
    // números na tela.
    
    public class InsertingInAListSample
    {
        public static void Run()
        {
            var insertingList = new InsertList(5);
            insertingList.StartInsert();
        }
    }

    public class InsertList
    {
        private List<int> _randomicList;
        private Random _random;
        CountdownEvent countdownEvent;
        public int WorkersCount { get; private set; }
        private object sync = new object();
        public InsertList(int workers)
        {
            _randomicList = new List<int>();
            _random = new Random();
            countdownEvent = new CountdownEvent(workers);
            WorkersCount = workers;
        }

        public void StartInsert(int quantityNumbers = 2)
        {
            for (int i = 0; i < WorkersCount; i++)
            {
                var thread = new Thread(() => Insert(quantityNumbers, countdownEvent));
                thread.Name = $"#{i}";
                thread.Start();
            }

            countdownEvent.Wait();

            Console.WriteLine("\n\nFinalizando inserção concorrente\n");
            for (int i = 0; i < _randomicList.Count; i++)
            {
                Console.WriteLine($"random[{i}] = {_randomicList[i]}");
            }
        }
        public void Insert(int quantity, CountdownEvent countdownEvent)
        {
            while (quantity > 0)
            {
                var number = _random.Next(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} inserting number {number} \t rest quantity to insert {quantity}");
                InsertNumber(number);
                quantity--;
            }

            countdownEvent.Signal();
        }
        private void InsertNumber(int number)
        {
            lock (sync)
            {
                _randomicList.Add(number);
            }
        }
    }
}