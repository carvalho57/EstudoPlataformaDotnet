using System;
using System.Threading;

namespace code.Threadings
{
    public class TimerSample 
    {
        public static void Run()
        {
            var timer = new Timer(Execute, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
            Console.ReadLine();            
        } 

        private static void Execute(object param)
        {
            Console.WriteLine($"Executing Method from 3 to 3 seconds");
        }
    }
}