using System;
using System.Collections.Generic;
using System.Linq;

namespace PaginacaoExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = GetList();
            char opcao;
            bool sair = false;;

            Console.Write("Informe o tamanho das paginas: ");
            int pageLength = int.Parse(Console.ReadLine());

            var paginacao = new Paginacao<string>(names,pageLength);
            do {
                Console.WriteLine("j - para esquerda");
                Console.WriteLine("k - para direita");
                Console.WriteLine("l - para sair");
                Console.Write("Informe a opção: ");
                opcao = Console.ReadLine()[0];  

                switch(opcao) {
                    case 'j':
                        paginacao.PreviousPage().PresentPage();
                        break;
                    case 'k':
                        paginacao.NextPage().PresentPage();
                        break;
                    case 'l':
                        sair = true;
                        break;                    
                }

                Console.Write("Pressione Qualquer tecla para continuar");
                Console.ReadKey();

            }while(!sair);
        }
        public static List<string> GetList() {
            List<string> names = new List<string>(){"amanda", "diego","carlos","diogo","manu","bruno","gabriel","mayara","marcos","jonatas","patricia"
                , "caral", "daniela", "isabela", "eduardo","fernanda","tayline"};
            names.Sort();
            return names;
        }
        
    }
}
