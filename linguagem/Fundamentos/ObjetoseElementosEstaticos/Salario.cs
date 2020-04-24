using System;

namespace ObjetoseElementosEstaticos {
    public class Salario {

        public double Valor { get; private set; }
        public int Mes {get; private set;}
        public Salario() {
            Console.WriteLine("Criando Objeto (1)");            
        }
        public Salario(double valor, double bonus) {
            Console.WriteLine("Criando o objeto (2)");
            Valor = valor + (valor * bonus);
        }

        public Salario(double valor, double bonus, int mes) : this(valor,bonus) {
            Console.WriteLine("Criando objeto (3)");
            Mes = mes;
        }
        public void MostrarValor() {
            Console.WriteLine(Valor);
        }
        public static void Run() {
            Salario salario = new Salario(1500, 0.3,3);
            Console.WriteLine($"Valor: {salario.Valor}");
            Console.WriteLine($"Mes: {salario.Mes}");             
        }
    }
}