using System;
namespace ObjetoseElementosEstaticos {

    public class Bola {
        public static int numeroBolas;
        public Bola() {
            numeroBolas ++;
        }

        public void PrintNumberOfBolas()
        {
            Console.WriteLine(numeroBolas);
        }
    }
}