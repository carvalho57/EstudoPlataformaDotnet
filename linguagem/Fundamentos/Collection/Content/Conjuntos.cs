using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Collection.Content {

    /*
        Não permite elementos duplicados
    */
    public class Conjunto {
        public void Run() {
            //HashSetOperation();
            ComparandoObjetosnoSet();
        }

        public void HashSetOperation() {
            HashSet<string> dias = new HashSet<string>();
            dias.Add("Segunda-Feira");
            dias.Add("Terça-Feira");
            dias.Add("Quarta-Feira");
            dias.Add("Quinta-Feira");
            dias.Add("Sexta-Feira");
            dias.Remove("Quarta-Feira");

            foreach(string dia in dias) {
                Console.WriteLine(dia);
            }
        }

        private void ComparandoObjetosnoSet() 
        {
            var contas = new HashSet<Conta>();
            contas.Add(new Conta(6543));
            contas.Add(new Conta(7154));
            contas.Add(new Conta(2122));
            contas.Add(new Conta(2123));
            contas.Add(new Conta(2123));
            contas.Add(new Conta(2123));

            foreach(var conta in contas) {
                Console.WriteLine(conta);
            }
        }
    }
    public class Conta : IEquatable<Conta> {
        public int Numero {get;set;}
        public Conta(int numero) {
            Numero = numero;
        }
        public override string ToString() {
            return $"Numero Conta: {Numero}";
        }

        public override bool Equals(object obj) {
            return Equals(obj as Conta);
        }

        public bool Equals(Conta other)
        {
            if(other == null)
                return false;
            
            return this.Numero.Equals(other.Numero);
        }

        public override int GetHashCode() {
            int hash = 27;
            hash = (13 * hash) + Numero.GetHashCode();
            hash = (13 * hash) + Numero.GetHashCode();//Outro fields
            return hash;
        }
    }
}
