using System;
using Heranca.Concepts;
using Heranca.Exercicios;
/*Um dos pilares da orientação a objeto
Herança Tipo de relacionamento: é um
O "o que" é difinido pela assinatura do método
O "como" é definido pela implementação do método 

Interface - Denifinem funcionalidades comuns para classes 
Programar para interfaces e não para Implementação
Associação Tipo de relacionamento: tem-um

*/
namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            // UsingAnimal();
            // ImplementandoInterface();
            //Exercicio1();
            Exercicio2();
        }

        static void UsingAnimal() {
            Cachorro animal = new Cachorro {
                Altura = 1.3,
                Peso = 54
            };
            animal.Mover();
            animal.MostrarDados();
            animal.Latir();           
        }

        static void ImplementandoInterface() {
            Carro carro = new Carro();
            carro.NomeMotor = "Santana";
            carro.Ligar();
            carro.Roubar();
        }

        static void Exercicio1() {
            Ponto2D ponto2 = new Ponto2D(5,6);
            ponto2.Imprimir();
            Ponto3D ponto3 = new Ponto3D(5,6,7);
            ponto3.Imprimir();
        }

        static void Exercicio2() {
            Porta porta = new Porta(2.10,1.0);            
            Console.WriteLine(porta.Aberta);
            porta.Abrir();
            Porta clonePorta = (Porta)porta.Clone();
            Console.WriteLine(porta.Aberta);
            clonePorta.AlterarAltura(3.20);
            Console.WriteLine(clonePorta.Altura);
            Console.WriteLine(porta.Altura);
        }
    }
}
