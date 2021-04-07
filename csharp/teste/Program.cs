using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace teste
{

    public class Program
    {
        public static void PercorreAte()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} ");
            }

        }
        public static void Main(string[] args)
        {
            var thread = new Thread(PercorreAte);
            var thread2 = new Thread(PercorreAte);
            thread.Start();
            thread2.Start();
            
        }
    }
}
