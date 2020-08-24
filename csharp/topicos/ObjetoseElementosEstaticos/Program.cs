using System;

namespace ObjetoseElementosEstaticos
{
    class Program
    {
        static void Main(string[] args)
        {
            Bola bola = null;
            for(int count = 0; count < 10; count++) {
                bola = new Bola();
            }

            bola.PrintNumberOfBolas();
            
            // Salario.Run();
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
