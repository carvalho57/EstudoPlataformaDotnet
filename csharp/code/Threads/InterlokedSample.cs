using System.Threading;

namespace code.Threadings
{
    public class Number
    {
        public int Value { get; private set; }

        public void AddValue(int value)
        {
            Interlocked.Add(ref value, this.Value);
        }
    }
}