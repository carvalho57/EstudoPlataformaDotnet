using System;
using System.Diagnostics.CodeAnalysis;

namespace Arrays {
    public class Prova : IComparable<Prova>{
        public string NomeAluno { get; set; }
        public double Nota { get; set; }

        public Prova(string nomeAluno, double nota) {
            NomeAluno = nomeAluno;
            Nota = nota;
        }
        public int CompareTo([AllowNull] Prova other)
        {
            if(Nota == other.Nota) {
                return 0;
            } else if(Nota > other.Nota) {
                return 1;
            } else {
                return -1;
            }
        }
    }
}