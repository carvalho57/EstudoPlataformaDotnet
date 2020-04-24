using System;

namespace Heranca.Concepts {

    public class Cachorro : Animal {
      
        public Cachorro() {
            Console.WriteLine("Construtor (Cachorro)");
            Console.WriteLine("Encadeamento de construtores para a criação de objeto î");
        }
        public void Latir() {
            Console.WriteLine($"{Classe} Au-AU");            
        }

        public override string ToString() {
            return $"Este é um {Classe} do tipo Cachorro";
        } 
    }
}