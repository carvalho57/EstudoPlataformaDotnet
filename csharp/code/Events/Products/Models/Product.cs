namespace code.Events{
    public class Product {
        public Product(string name, int quantityOnstock, decimal price)
        {
            Name = name;
            QuantityOnstock = quantityOnstock;
            Price = price;
        }

        public string Name { get; private set; }
        public int QuantityOnstock { get; private set; }
        public decimal Price { get; private set; }

        
        public void DecreaseQuantity(int quantity) {            
            QuantityOnstock -= quantity;
        }
    }
}