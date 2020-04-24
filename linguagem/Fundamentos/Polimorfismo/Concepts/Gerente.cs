namespace Polimorfismo.Concepts {

    public class Gerente : Funcionario {

        public Gerente(double salario) : base(salario) {

        }
        protected override double GetBonificacao() {
            return this.Salario * 0.6;
        }

        public override double CalcularSalario() {
            return this.Salario + GetBonificacao();
        }

        public override string ToString() {
            return "Gerente";
        }
    }
}