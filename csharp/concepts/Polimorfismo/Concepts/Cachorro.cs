using System;

namespace Polimorfismo.Concepts {
    public class Cachorro : Animal {
        public override string Falar(){ 
            return "Au-Au";
        }

        public string Morder() {
            return "Nhac";
        }
    }
}