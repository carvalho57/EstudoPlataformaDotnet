using System;

namespace ApiAuth.Models {
    public class ProductModel {
        public ProductModel(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Guid Id { get; private set; }        
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}