using System;
using review.Collections;
using review.Polimorfismo;
using review.Generic;

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
            new Generics().Run();
        }
    }
}
