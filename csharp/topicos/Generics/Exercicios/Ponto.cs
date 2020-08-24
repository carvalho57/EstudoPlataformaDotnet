using System;

namespace Generics.Exercicios {
    public struct Ponto<T> {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }        
        
        public Ponto(T z, T y, T x)
        {
            X = x;
            Y = y;
            Z = z;
            
        }

        public override string ToString() {
              return $"X: {X} Y: {Y} Z: {Z}";
        }
    }
}