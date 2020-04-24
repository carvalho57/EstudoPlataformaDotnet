using System;
namespace Tratamento.Exceptions {
    public class Calculator {
        public double Dividir(double a, double b)  {
            try {
                Division division = new Division(a,b);
                return division.Dividir();
            }catch(DivisaoException de) {
                throw new CalculoException("Erro de cálculo",de);
            }
        }

    }
}