using System;
using Collection.Content;
using Collection.Exercicio;
namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Conteudo();           
        }
        
        static void Conteudo() {
            Console.WriteLine("Conteudo");
            new Lista().Run();
            new Conjunto().Run();
            new Dicionario().Run();
            new Fila().Run();
            new Pilha().Run();
        }
    }
}
