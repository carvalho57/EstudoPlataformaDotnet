using System;
using System.Collections.Generic;
using review.Heranca;

namespace review.Polimorfismo {
    /*
        E a capacidade de um objeto poder assumir varias formas 
    */
    public class Polimorfos {
        public static void Run() {
            ProfissionalFutebol jogador = new Jogador("Jose", "Henrique",new DateTime(1998,05,3), DateTime.Now,15000);
            ProfissionalFutebol tecnico = new Tecnico("Marcos", "Vieira",new DateTime(1968,05,3), DateTime.Now,10000);
            ProfissionalFutebol treinador = new TreinadorFisico("Mauricio", "Vargas",new DateTime(1990,05,3), DateTime.Now,8000);

            ApresentarProfissional(jogador);
            ApresentarProfissional(tecnico);
            ApresentarProfissional(treinador);

            IList<IMeiosPagamento> opcoes = new List<IMeiosPagamento> {
                new Boleto(),
                new CartaoCredito()
            };

            Pagar(opcoes[1]);
        }   

        public static void ApresentarProfissional(ProfissionalFutebol profissional) {
            Console.WriteLine(profissional.Apresentacao());
        }

        
        public interface IMeiosPagamento {
            void Pagar();
        }

        public class Boleto : IMeiosPagamento
        {
            public void Pagar()
            {
                Console.WriteLine("Procedimentos para pagar boleto...");
            }
        }

        public class CartaoCredito : IMeiosPagamento
        {
            public void Pagar()
            {
                Console.WriteLine("Procedimentos para pagar cartão de crédito...");
            }
        }

        public static void Pagar(IMeiosPagamento pagamento) {
            Console.WriteLine("Informe os dados");
            pagamento.Pagar();
        }
    }
}