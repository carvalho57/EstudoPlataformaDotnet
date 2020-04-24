using System;
using Polimorfismo.Concepts;
using Polimorfismo.Exercicio;

namespace Polimorfismo
{
    /*Tratar vários tipos de dados através de forma homogênea
        - A referência a um objeto é feita atráves de um tipo mais genérico
        - Podendo variar na execução pelo tipo instanciado
        
        Na prática uma referencia  generica referencia um objeto na memória mais especifico;

        Classe Abstratas
            Classes comuns que implementam funcionalidade comuns a objetos
            Não faça sentido instanciar
        Metodos
            Usados quando não tem sentido ter
            uma implementação do método na superclass


        Polymorphism means that you can have multiple classes that can be used interchangeably, even though each class implements the same properties or methods in different ways.
        */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PolimorfismoComGatoECachorro();
            //PolimorfismoComInterface();
            //ClasseAbstrata();            
        }


        static void ClasseAbstrata() {
            //Funcionario f = new Funcionario(); tente instanciar
            Funcionario gerente = new Gerente(8000);
            Funcionario analista = new Analista(5000);

            CalcularSalario(gerente);
            CalcularSalario(analista);
        }

        private static void CalcularSalario(Funcionario func) {
            Console.WriteLine(func);
            Console.WriteLine($"O salário é {func.CalcularSalario()}");
        }

        static void PolimorfismoComInterface() {
            Selo selo = new Selo();
            Quadrinho quadrinho = new Quadrinho();
            ImprimirColecao(selo);
            ImprimirColecao(quadrinho);
        }

        private static void ImprimirColecao(ICollecionavel c) {
            Console.WriteLine($"Esta é uma coleção de {c.GetNomeColecao()}");
        }
        
        static void PolimorfismoComGatoECachorro() {
            Animal cachorro = new Cachorro();
            Animal gato = new Gato();
            EmitirSomAnimal(cachorro);
            EmitirSomAnimal(gato);
            
            //cachorro.Morder(); referencia genérica não enchega o objeto
            if(cachorro is Cachorro) {
                ((Cachorro)cachorro).Morder();
                //Antes de fazer cast fazer o teste para antecipar o erro
            }
        }

        private static void EmitirSomAnimal(Animal animal) {
            Console.WriteLine($"Animal Falando: {animal.Falar()}");
        }
    }
}
