using System;
using System.Threading;

namespace code.Events
{
    public class Counter
    {
        public event EventHandler<int> Progress;
        public void Start(int limit)
        {
            for (int i = 1; i <= limit; i++)
            {
                Progress?.Invoke(this, i);
                Thread.Sleep(500);
            }
        }
    }
}