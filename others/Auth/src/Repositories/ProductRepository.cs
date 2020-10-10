using System;
using System.Collections.Generic;
using System.Linq;
using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public class ProductRepository
    {
        private readonly List<ProductModel> _product;

        public ProductRepository() {
            _product = new List<ProductModel>() {
                new ProductModel("Maça",12.56M),
                new ProductModel("Pera",4.23M),
                new ProductModel("Banana",14.06M),
                new ProductModel("Manga",1.46M),
                new ProductModel("Jabuticaba",0.56M),
            };
        }

        public List<ProductModel> Get() => _product;
    }
}