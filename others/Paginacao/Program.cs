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
            
            PresentLine(names);
            var pageLength = 4;
            var pageNumber = 3;            

            Console.WriteLine("------------------\n");
            Console.WriteLine("Page 3");
            Present(names.Skip((pageNumber - 1) * pageLength).Take(pageLength).ToList());

            Console.WriteLine("------------------\n");
            Console.WriteLine("Page 3");
            var paginacao = new Paginacao<string>(names,4);
            var pagesix = paginacao.GetPage(pageNumber);
            foreach(var item in pagesix) {
                Console.WriteLine($"{item}");
            }

        }
        public static List<string> GetList() {
            List<string> names = new List<string>(){"amanda", "diego","carlos","diogo","manu","bruno","gabriel","mayara","marcos","jonatas","patricia"
                , "caral", "daniela", "isabela", "eduardo","fernanda","tayline"};
            names.Sort();
            return names;
        }
        static void Present(List<string> names) => names.ForEach(name => Console.WriteLine(name));
        static void PresentLine(List<string> names) => names.ForEach(name => Console.Write($"{name} "));
    }
}
