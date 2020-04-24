using System;

namespace review.Heranca {
    public abstract  class ProfissionalFutebol {
        public string Nome { get; private set; }   
        public string SobreNome {get;private set;}
        public DateTime Nascimento { get; private set; }
        public DateTime Contratacao { get; private set; }    
        public double Salario {get;private set;}

        public ProfissionalFutebol(string nome, string sobrenome, DateTime nascimento,
         DateTime contratacao, double salario) 
        {
            Nome = nome;
            SobreNome = sobrenome;
            Nascimento = nascimento;
            Contratacao = contratacao;
            Salario = salario;
        }

        public virtual string Apresentacao() {
            return $"Olá meu nome é {Nome} {SobreNome} e eu sou um profissional do futebol";
        }

        public override string ToString() {
            return $"Nome: {Nome} {SobreNome} | Data Nascimento {Nascimento.ToShortDateString()}";
        }
    }
}


