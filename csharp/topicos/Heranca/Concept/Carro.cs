using System;

namespace Heranca.Concepts {

    public class Carro : IMotorizado, IRoubavel
    {
        public string NomeMotor {get;set;}

        public void Ligar()
        {
            Console.WriteLine("Carro ligado");
        }

        public void Roubar()
        {
            Console.WriteLine("Carro Roubado");
        }
    }
}