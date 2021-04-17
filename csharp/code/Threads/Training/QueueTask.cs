// Implemente uma fila de execução de tarefas. Esta fila é uma thread que fica aguardando
// tarefas. Quando uma ou mais tarefas chegam, elas são executadas na ordem que chegaram.
// Uma tarefa é representada por um delegate Action. Crie uma classe QueueTask para
// representar a fila de tarefas e um método Enqueue() que permite enfileirar uma tarefa para
// execução.
// Utilize um AutoResetEvent para gerenciar a fila, de forma que a thread da fila de tarefas deve
// ficar bloqueada aguardando até que uma tarefa esteja disponível.
// Escreva um código que enfileire algumas tarefas para testar o uso da fila.
using System;
using System.Collections.Generic;
using System.Threading;

namespace code.Threadings
{
    public class QueueTaskSample
    {
        public static void Run()
        {
            var queueTask = new QueueTask();
            queueTask.Enqueue(() => Console.WriteLine("Primeira task a ser adicionanda"));
            queueTask.Enqueue(() => Console.WriteLine("Essa task ja esta aqui"));
            queueTask.Enqueue(() => Console.WriteLine("Perdido no meio da multidao"));
            queueTask.Enqueue(() => Console.WriteLine("Ultima task na mão"));
            new Thread(() => EnqueueTask(queueTask)).Start();
            new Thread(() => Execute(queueTask)).Start();
        }

        private static void Execute(QueueTask queue)
        {
            queue.Run();
        }
        private static void EnqueueTask(QueueTask queue)
        {
            int i = 0;
            while (true)
            {
                queue.Enqueue(() => Console.WriteLine($"Executando task #{i++}"));
                Thread.Sleep(200);
            }
        }
    }
    public class QueueTask
    {
        private readonly Queue<Action> _actionQueue;
        private readonly object sync = new object();
        private AutoResetEvent _enqueueEvent; //Funciona com uma cancela deixando um thread passar        

        public QueueTask()
        {
            _actionQueue = new Queue<Action>();
            _enqueueEvent = new AutoResetEvent(true);
        }
        public void Run()
        {
            while (true)
            {
                lock (sync)
                {
                    Action action;
                    _actionQueue.TryDequeue(out action);                    
                    action?.Invoke();
                }
                Thread.Sleep(500);
            }
        }
        public void Enqueue(Action action)
        {            
            _enqueueEvent.WaitOne();
            lock (sync)
            {                
                _actionQueue.Enqueue(action);
            }
            _enqueueEvent.Set();
        }
    }
}