using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace code.Threadings
{
    public class CanguruRaceSample
    {
        public static void Run()
        {
            var corrida = new CanguruRace(
                new List<Canguru>()
                {
                    new Canguru("Jose"),
                    new Canguru("Carlos"),
                    new Canguru("Amanda"),
                    new Canguru("Bruna"),
                    new Canguru("Zenildo"),
                    new Canguru("Cuxinto"),
                }, 500);

            corrida.Iniciar();

        }
    }
    public class CanguruRace
    {
        private List<Canguru> _ranking { get; set; }
        private Stopwatch Cronometro;
        public int MaxDistancia { get; private set; }
        public List<Canguru> Cangurus { get; private set; }
        private Thread[] Threads;
        public CanguruRace(List<Canguru> cangurus, int maxDistancia)
        {
            MaxDistancia = maxDistancia;
            Cangurus = cangurus ?? new List<Canguru>();
            _ranking = new List<Canguru>(cangurus.Count);
            Threads = new Thread[cangurus.Count - 1];

            Cangurus?.ForEach(canguru => canguru.Chegou += OnChegou);
            Cronometro = new Stopwatch();
        }

        public void OnChegou(Canguru sender)
        {
            lock (this)
            {
                sender.Tempo = Cronometro.Elapsed;
                _ranking.Add(sender);
            }
        }

        public void Iniciar()
        {
            Cronometro.Start();

            for(int i = 0 ; i < Threads.Length; i++)
            {
                int j = i; //Clojuse (use ou morra)            
                Threads[j] = new Thread(() => Cangurus[j].Pular(this.MaxDistancia));
                Threads[j].Start();
            }

            for(int i = 0 ; i < Threads.Length; i++)
                Threads[i].Join();

            Cronometro.Stop();
            Console.WriteLine("A corrida acabou!!");
            MostrarRanking();
        }

        public void MostrarRanking()
        {            
            Console.WriteLine("\n\nRanking: \n");
            for (int i = 0; i < _ranking.Count; i++)
            {
                Console.WriteLine($"{i + 1}º {_ranking[i].Nome} em {_ranking[i].Tempo.Milliseconds} ms");
            }
        }
    }

    public class Canguru
    {
        private static Random random = new Random();
        public string Nome { get; private set; }
        public int Distancia { get; private set; }
        public TimeSpan Tempo { get; set; }
        public event Action<Canguru> Chegou;

        public Canguru(string nome)
        {
            Nome = nome;
        }
        public void Pular(object distancia)
        {
            var maxDistancia = (int)distancia;
            while (true)
            {
                Distancia += random.Next(60);
                Console.WriteLine($"Canguru {Nome} alcançou {Distancia:00}cm");

                if (Distancia >= maxDistancia)
                    break;
                Thread.Sleep(300);
            }

            Chegou?.Invoke(this);
        }

    }
}