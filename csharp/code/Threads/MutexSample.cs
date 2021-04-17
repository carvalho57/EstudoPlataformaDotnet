using System;
using System.Threading;

namespace code.Threadings
{
    //Semaforo binário
    public class MutexSample
    {
        public static void Run()
        {
            //Não estou certo do funcionamento de named mutex on linux
            //mutex - lock entre processos
            var mutex = new Mutex(false, "lock"); //mutex com nome lock, compartilha esse mutex entre processos
            bool aquired = mutex.WaitOne(); //tenta obter o lock
            try
            {
                if (!aquired)
                {
                    Console.WriteLine("Possivel apenas uma instância da aplicação");
                    return;
                }

                Console.WriteLine("Aplicação executando");
                Console.ReadLine();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

    }
}
