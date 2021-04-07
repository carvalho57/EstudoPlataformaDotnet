
namespace code.Delegates
{
    public delegate int Comparison<in T>(T left, T right);
    public class DelegateSample
    {                        
        public Comparison<int> comparator;
        public static void Run()
        {
            CalculatorExample.Run();
        }        
    }
}