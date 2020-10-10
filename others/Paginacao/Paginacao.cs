using System;
using System.Collections.Generic;
using System.Linq;

namespace PaginacaoExemplo
{
    /*
        [ ] Paginar uma fonte de dados.
        [ ] Mostar se o usuário pode ou não avançar | retroceder         
    */
    public class Paginacao<T>
    {
        private const int InitialPage = 1;
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get { return Elements.Count / PageSize; } }
        public bool HasPreviousPage { get { return CurrentPage > 0; }}
        public bool HasNextPage { get { return CurrentPage < TotalPages; }}
        private List<T> Elements { get; set; }
        public Paginacao(List<T> elements, int pageSize)
        {
            Elements = elements;
            CurrentPage = InitialPage;
            PageSize = pageSize;
        }

        public IReadOnlyList<T> NextPage()
        {
            if (!HasNextPage)
                return new List<T>();

            CurrentPage++;
            return GetCurrentPage();

        }
        public IReadOnlyList<T> PreviousPage()
        {
            if (!HasPreviousPage)
                return new List<T>();

            CurrentPage--;
            return GetCurrentPage();
        }

        public IReadOnlyList<T> GetCurrentPage() => GetPage(CurrentPage);

        public IReadOnlyList<T> GetPage(int number)
        {
            return Elements
                .Skip((number - 1) * PageSize)
                .Take(PageSize)
                .ToList()
                .AsReadOnly();
        }

    }
}