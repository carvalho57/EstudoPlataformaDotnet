using System;
using System.Collections.Generic;
using System.Linq;

namespace PaginacaoExemplo
{
    public class Paginacao<T>
    {
        private const int InitialPage = 1;
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get { return Elements.Count / PageSize; } }
        private List<T> Elements { get; set; }
        public Paginacao(List<T> elements, int pageSize)
        {
            Elements = elements;
            CurrentPage = InitialPage;
            PageSize = pageSize;
        }

        public IReadOnlyList<T> NextPage()
        {
            if (CurrentPage < TotalPages)
                CurrentPage++;
            return GetCurrentPage();

        }
        public IReadOnlyList<T> PreviousPage()
        {
            if (CurrentPage > 0)
                CurrentPage--;
            return GetCurrentPage();
        }

        public IReadOnlyList<T> GetCurrentPage()
        {
            return Elements
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList()
                .AsReadOnly();
        }

        public IReadOnlyList<T> GetPage(int number) {
            return Elements
                .Skip((number - 1) * PageSize)
                .Take(PageSize)
                .ToList()
                .AsReadOnly();
        }

    }
}