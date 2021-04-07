using System;
using System.Threading;
using System.Threading.Tasks;

namespace code.Lambda
{
    public class LambdaSample
    {
        public static void Run()
        {
            SimpleLambda();
            ExecuteFunction((name) => $"Hello Func {name}", "Gabriel");
            ExecuteAsyncLambda();
        }

        public static void SimpleLambda()
        {
            Action<string> helloexpressionLambda = name => Console.WriteLine($"Hello {name}");
            Action<string> hellostatementLambda = name =>
            {
                string hello = $"Hello {name}\n";
                Console.WriteLine(hello);
            };

            helloexpressionLambda("Gabriel");
            hellostatementLambda("Gabriel");
        }

        public static void ExecuteFunction(Func<string, string> func, string nome)
        {
            Console.WriteLine(func(nome));
        }

        public static void ExecuteAsyncLambda()
        {
            Task.Run(async () =>
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                Console.WriteLine(i);                                                                                                
                            }
                            await Task.Delay(100);
                        });
        }
    }
}