using System.Collections.Generic;
using System;
namespace Collection.Content {
    /*
        Utilizar quando necessario fazer mapeamento
        Chave unica
    */
    public class Dicionario {
        public void Run() {
            var e1 = new Estado("Rio Grande do Sul");
            var e2 = new Estado("Santa Catarina");
            var e3 = new Estado("Paraná");

            Dictionary<string,Estado> estados = new Dictionary<string, Estado>();
            estados.Add("RS",e1);
            estados.Add("SC",e2);
            estados["PR"] = e3;            
            //estados.Remove("PR");
            foreach(var estado in estados) {
                System.Console.WriteLine($"chave:{estado.Key} valor{estado.Value.Nome}");                
            }
            Console.Write("Vamos visuvizalizar um estado de perto, informe uma que exista: ");
            var chave = Console.ReadLine();

            try{
                var estado = estados[chave];
                Console.WriteLine(string.Format("Este estado é o {0}",estado.Nome));
            }catch (KeyNotFoundException ex) {
                Console.WriteLine($"Ixxe, digitou a chave errada toma aqui uma exceção: {ex.Message}");
            }
            
            
        }
    }
    public class Estado {
        public string Nome {get;set;}
        public Estado(string nome) {
            Nome = nome;
        }
    }
}