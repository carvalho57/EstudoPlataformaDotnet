using System;

namespace Heranca.Concepts {
      public class Gato : Animal {
      
        public Gato() {
            Console.WriteLine("Construtor (Gato)");
            Console.WriteLine("Encadeamento de construtores para a criação de objeto î");
        }
        public void Miar() {
            Console.WriteLine($"{Classe} Miau");            
        }

        public override string ToString() {
            return $"Este é um {Classe} do tipo Gato";
        } 
    }
}