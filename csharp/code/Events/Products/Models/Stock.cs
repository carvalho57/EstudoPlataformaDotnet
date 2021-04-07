using System;
using System.Collections.Generic;


namespace code.Events
{

    public class Stock
    {
        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products
        {
            get { return _products.AsReadOnly(); }
        }

        public Stock()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void DecreaseQuantityOfStock(object sender, List<Item> orderItems)
        {
            orderItems.ForEach(item => item.Product.DecreaseQuantity(item.Quantity));
            Console.WriteLine("Descreased quantity of product");
        }
    }

}