using System;
using System.Collections;

namespace review.Heranca {
    
    public class Tecnico : ProfissionalFutebol {
        /*
            Encapsulamento - Ocultar detalhes de implementação, mostrar como ele funciona mas não com
            executa os serviços
        */
        public Tecnico(string nome, string sobrenome, DateTime nascimento, DateTime contratacao, double salario) : base(nome, sobrenome, nascimento, contratacao, salario)
        {
            
        }
        public override string Apresentacao() {
            return $"Olá meu nome é {Nome} {SobreNome} e eu sou um técnico";
        }
        private void EscalarTime() {
            Console.WriteLine("Jogadores: José, João, Maria, Marta, Pele, Kaka, Rodrigo Morais");
        }
        private void DefinirTatica() {
            Console.WriteLine("Definindo tática ofensiva");
        }

        public void FazerPreparativoParaJogo() {
            DefinirTatica();
            EscalarTime();
        }
    }   
}