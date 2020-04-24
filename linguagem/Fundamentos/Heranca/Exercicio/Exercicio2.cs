/*O C# possui uma interface chamada ICloneable, que pode ser implementada por classes que
são capazes de gerar cópias de objetos. Classes que implementam esta interface devem
implementar o método Clone(). Dentro deste método é implementada a lógica para criar um
novo objeto com base no objeto original.
Com base nisto, crie uma classe Porta que suporta a criação de novos objetos (cópia). Ela deve
ter os fields altura (double), largura (double) e aberta (boolean). Também deve possuir os
métodos Abrir(), Fechar() e os valores dos fields devem ser expostos para fora da classe
através de read-only properties.
Como uma porta pode criar outras cópias dela mesma, você deve implementar o método
Clone() na classe, o qual deve criar um novo objeto com os valores dos atributos copiados e
retorná-lo.*/
using System;

namespace Heranca.Exercicios {
    public class Porta : ICloneable {
        public double Altura { get; private set; } 
        public double Largura {get;private set;}
        private bool _aberta;
        public bool Aberta{
            get{
                return _aberta;
            }
            set{
                if(_aberta != value) {
                    _aberta = value;
                }
            }
        }

        public Porta(double altura, double largura) {
            Altura = altura;
            Largura = largura;
        }
        public void Abrir() {
            Aberta = true;        
            Console.WriteLine("Abrindo Porta");
        }
        public void Fechar() {
            Aberta = false;
            Console.WriteLine("Fechando Porta");
        }
        public void AlterarAltura(double altura) {
            Altura = altura;
        }
        public object Clone() {
            return this.MemberwiseClone();
        }

    }
}