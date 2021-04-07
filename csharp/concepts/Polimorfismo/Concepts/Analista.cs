namespace Polimorfismo.Concepts {

    public class Analista : Funcionario {        

        public Analista(double salario) : base(salario) {}

        protected override double GetBonificacao() {
            return this.Salario * 0.2;
        }

        public override double CalcularSalario()
        {
            return this.Salario + GetBonificacao();
        }

        public override string ToString() {
            return "Analista";
        }
    }
}