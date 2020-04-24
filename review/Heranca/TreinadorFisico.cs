using System;

namespace review.Heranca {
    public class TreinadorFisico : ProfissionalFutebol
    {
        public TreinadorFisico(string nome, string sobrenome, DateTime nascimento, DateTime contratacao, double salario) : base(nome, sobrenome, nascimento, contratacao, salario)
        {
        }
        public void PreparacaoFisica() {
            Console.WriteLine("Preparar jogador");
        }
    }
}