using System;
using System.Collections.Generic;

namespace Collection.Content {
    public class Fila {
        public void Run() {

            var queue = new Queue<char>();
            while(true) {
                Console.Write("Elemento: ");
                var element = Console.ReadLine();

                if(string.IsNullOrEmpty(element)){
                    break;
                }
                char first = element[0];
                queue.Enqueue(first);
            }

            foreach(var element in queue) {
                Console.WriteLine($"=> {element}");
            }
        }
    }
}