using System;
using System.Collections.Generic;

namespace PaginacaoExemplo
{
    public static class ExtesoesPagina
    {
        public static void PresentPage(this IReadOnlyList<string> list)
        {
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
