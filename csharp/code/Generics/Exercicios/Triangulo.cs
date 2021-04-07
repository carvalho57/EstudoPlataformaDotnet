namespace code.Generics.Exercicios {
    public struct Triangulo<T> {
        public T P1{get;set;}
        public T P2{get;set;}
        public T P3{get;set;}

        public Triangulo(T p1, T p2, T p3)
        {   
            P1 = p1;
            P2   = p2;
            P3 = p3;        
        }

        public override string ToString() {
            return $"P1: {P1} P2: {P2} P3: {P3}";
        }
    }
}