using System;
namespace Heranca.Concepts  {
    public class Animal {
        public double Altura{get;set;}
        public double Peso{get;set;}
        
        protected const string Classe = "Mamífero";

        public Animal() {
            Console.WriteLine("Construtor (Animal)");
        }
        public void Mover() {
            Console.WriteLine($"Animal {Classe} se moveu");
        }

        public void MostrarDados() {
            Console.WriteLine($"Altura: {Altura} Peso: {Peso}");
        }        

        public override string ToString() {
            return "Eu sou uma Animal";
        }
    }
}