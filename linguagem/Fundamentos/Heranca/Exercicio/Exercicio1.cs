/*Crie duas classes: Ponto2D e Ponto3D. Ponto2D possui como fields as coordenadas x e y,
enquanto Ponto3D, além delas, também possui a coordenada z. Utilize a relação de herança
para representar estas classes.
A respeito dos construtores, Ponto2D deve ter apenas um construtor, que recebe os valores
de x e y como parâmetros (tipo double). Já Ponto3D também deve ter apenas um construtor,
que deve receber x, y e z como parâmetros (também do tipo double). Dica: Se a relação de
herança e a declaração dos construtores foram feitas corretamente, você deverá,
obrigatoriamente, chamar o construtor da superclasse explicitamente.
Ambas as classes devem implementar o método Imprimir(), que exibe no console os valores
das coordenadas do objeto.*/
using System;

namespace Heranca.Exercicios {

    public interface IPonto {
        void Imprimir();
    }

    public class Ponto2D : IPonto {
        public double X { get; protected set; }
        public double Y { get; protected set; }

        public Ponto2D(double x, double y) {
            X = x;
            Y = y;
        }

        public virtual void Imprimir()
        {
            Console.WriteLine($"x:{X} y:{Y}");
        }
    }

    public class Ponto3D : Ponto2D {
        public double Z { get; private set; }
        public Ponto3D(double x , double y, double z) : base(x,y)
        {
            Z = z;
        }

        public override void Imprimir() {                        
            Console.WriteLine($"x:{X} y:{Y} z:{Z}");
        }

    }
}