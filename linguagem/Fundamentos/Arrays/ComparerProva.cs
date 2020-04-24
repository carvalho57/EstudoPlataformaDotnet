using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Arrays {
    public class ComparerProva : IComparer<Prova>
    {
        public int Compare( Prova prova, Prova other)
        {
            if(prova.Nota == other.Nota) {
                return 0;
            } else if(prova.Nota > other.Nota) {
                return -1;
            } else {
                return 1;
            }
        }
    }
}