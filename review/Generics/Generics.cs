using System;
using System.Collections.Generic;

namespace review.Generics {
    /* O generic permite utilizar com se fosse placeholder para os tipos, então você
    define um T por exemplo e quando for instanciar uma classe você passa o tipo e onde tiver
    T vai ser substituido pelo tipo passado por parametro

    Por que utilizar?
        Reusabilidade,
        Evita os problemas de boxing e unboxing,
        Permite restringir o tipo passado como parametro
    */
    public class Generics {
        public static void Run() {
            var items = new Items<string>();
            items.Add("borracha");
            items.Add("lápis");
            items.Add("cadeira");

           // items.ForEach(x => Console.WriteLine(x));
        }
    }
    

    public class Items<T> where T: new() {   

        public ICollection<T> CollectionItems {get;set;}

        public Item() {
            CollectionItems = new List<T>();
        }

        public void Add(T item) {
            Items.Add(item);
        }

        public void Remove(T item) {
            Items.Remove(item);
        }

        public void ForEach(Action<T> function) {
            foreach(T item in CollectionItems) {
                function(item); 
            }
        }
    }    
}