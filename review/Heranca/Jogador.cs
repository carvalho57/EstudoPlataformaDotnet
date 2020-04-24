using System;

namespace review.Heranca {
    public class Jogador : ProfissionalFutebol
    {
        public Jogador(string nome, string sobrenome, DateTime nascimento, DateTime contratacao, double salario) : base(nome, sobrenome, nascimento, contratacao, salario)
        {
        }

        public override string Apresentacao() {            
            return $"Olá meu nome é {Nome} {SobreNome} e eu sou um jogador";
        }

        public void ChutarBola() {
            Console.WriteLine("Chutar uma bomba!");
        }
        public void FazerPasse(Jogador jogador) {
            Console.WriteLine($"Passe para o jogador: {jogador.Nome}");
        }
        
        public void CobrarPenalti() {
            Console.WriteLine("Bater no cantinho");
        }

        public void FazerEmbaixadinha(int value) {
            for(int i = 0; i < value; i++) {
                Console.WriteLine("Embaixadinha");
            }
        }
    }
}