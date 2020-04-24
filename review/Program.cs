using System;

namespace review
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Polimorfismo();
        }


        static void Polimorfismo() {
            Polimorfos.Run();
        }
        static void Collection() {
            new Colecao().Run();
        }

        static void Generics() {
            Generics.Run();
        }
    }
}
