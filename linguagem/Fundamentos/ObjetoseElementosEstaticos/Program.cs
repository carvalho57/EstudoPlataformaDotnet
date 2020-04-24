using System;

namespace ObjetoseElementosEstaticos
{
    class Program
    {
        static void Main(string[] args)
        {
    
            Bola b1 = new Bola();
            Bola b2 = new Bola();
            Bola b3 = new Bola();

            b3.PrintNumberOfBolas();
            
            //Salario.Run();
            //  Console.WriteLine($"PI: {Matematica.PI}");   
            //  Matematica matematica = new Matematica();
            //  Console.WriteLine($"Euler: {matematica.E}");
        }

        class Matematica {
            //Toda const é de forma implicita  static
            //Deve ter seu valor conhecido
            public const double PI = 3.1416;
            
            public readonly double E;

            public Matematica() {
                E = 2.7871828;
            }


        }
    }
}
