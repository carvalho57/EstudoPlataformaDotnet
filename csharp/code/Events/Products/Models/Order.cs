using System;
using System.Collections.Generic;

namespace code.Events{
    public class Order {
        private readonly List<Item> _items;
        public event EventHandler<List<Item>> PaymentOrderEvent;
        public Order()        
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item) {
            _items.Add(item);
        }

        public void Pay(decimal valor) {
            //trigger event
            PaymentOrderEvent?.Invoke(this, _items);
            // PaymentOrderEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}