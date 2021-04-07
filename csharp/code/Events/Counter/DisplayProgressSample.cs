using System;
using System.Threading.Tasks;

namespace code.Events 
{
    public class DisplayProgressSample
    {   
        public static void Run()
        {
            Counter counter = new Counter();
            counter.Progress += async (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs);
                await Task.Delay(100);
            };
            counter.Start(20);
        }
    }
}