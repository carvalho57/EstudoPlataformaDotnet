using System;

namespace code.Events
{
    public class EventStockSample
    {
        public static void Run()
        {
            var stock = new Stock();
            var banana = new Product("banana", 430, 3M);
            var pera = new Product("pera", 120, 1M);
            var manga = new Product("manga", 230, 2M);

            stock.AddProduct(banana);
            stock.AddProduct(pera);
            stock.AddProduct(manga);

            var item = new Item(banana, 10);

            var order = new Order();
            order.PaymentOrderEvent += stock.DecreaseQuantityOfStock;

            order.AddItem(item);
            order.Pay(10);            
        }
    }
}
