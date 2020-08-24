using System;
using System.Collections;
using Generics.Exercicios;
namespace Generics
{
    /*
        Evita problemas de boxing e unboxing;
        Verifica o tipo de dados no momento da compilação
        Podem ser aplicados com class, structs, interfaces e metodos (static)?
        Podem ser aplicados multiplos Tipos
        Generics Constraints  = Restringe o tipo de dado
    */
    class Program
    {
        static void Main(string[] args)
        {
            // var pacote = new PacoteGenerico<string>();            
            // pacote.Element1 = "10";
            // pacote.Element2 = "20";
            // pacote.Element3 = "30";

            // pacote.Mostrar();        
            new App().Run();
        }
    }
 
    public class PacoteGenerico<T> where T: class {
        public T Element1 {get;set;}        
        public T Element2 {get;set;}
        public T Element3 {get;set;}

        public void Mostrar() {
            Console.WriteLine("{0} {1} {2}",Element1, Element2, Element3);
        }

        public T RetornarValorPadrao() {
            T temp = default(T);
            return temp;
        }
    }
    public class Pacote {
        public object Element1 {get;set;}        
        public object Element2 {get;set;}
        public object Element3 {get;set;}

        public void Mostrar() {
            Console.WriteLine("{0} {1} {2}",Element1, Element2, Element3);
        }
    }
}
