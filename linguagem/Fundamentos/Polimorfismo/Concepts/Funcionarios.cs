using System;

namespace Polimorfismo.Concepts {

    public abstract class Funcionario {
        protected double Salario {get;set;}
        
        public Funcionario(double salario) {
            Salario = salario;
        }
        protected virtual double GetBonificacao() {
            return this.Salario * 1.2;
        }

        public abstract double CalcularSalario();        
    }
}