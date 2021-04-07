using System;
namespace Tratamento.Exceptions {
    public class Division {

        public double Numerador { get; set; }
        public double Denominador { get; set; }


        public Division(double numerador, double denominador)
        {
            this.Numerador = numerador;
            this.Denominador = denominador;
        }

        public double Dividir() {
            if(Denominador == 0) {
                throw new DivideByZeroException("Denominador não pode ser zero");
            }

            return Numerador/Denominador;
        }
    }
}