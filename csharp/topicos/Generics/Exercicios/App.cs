using System;

namespace Generics.Exercicios {
    public class App {
        
        public void Run() {
            Exercicio1();
            Exercicio2();
        }

        private void Exercicio1() {
            var factory = new ServiceFactory<LavaLouca>();
            var lavador = factory.NewInstance();
            lavador.Execute();
        }
        private void Exercicio2() {
            var tringulo = new Triangulo<double>(10.3,12.3,15.2);
            var tringulo1 = new Triangulo<int>(10,12,15);
            var tringulo2 = new Triangulo<byte>(10,11,4);

            var ponto = new Ponto<int>(10,2,3);
            var cordenadas = new Ponto<string>("10,2","12 minutos","12 segundos");
            var ponto2 = new Ponto<double>(10.3,23.2,32.1);

            Console.WriteLine(tringulo);
            Console.WriteLine(tringulo1);
            Console.WriteLine(tringulo2);
            Console.WriteLine(ponto);
            Console.WriteLine(cordenadas);
            Console.WriteLine(ponto2);
        }
    }

    public class LavaLouca : IService {
        public string NomeDoDenliquente { get; set; }
        public DateTime Horario { get; private set; }

        public LavaLouca() {
            NomeDoDenliquente = "Não Informado";
            Horario = DateTime.Now;
        }
        public LavaLouca(string name) {
            NomeDoDenliquente = name;
        }
        public void Execute()
        {
            Console.WriteLine($"Meu nome é {NomeDoDenliquente} e eu estou lavando a louça ...");
        }
    }
}
