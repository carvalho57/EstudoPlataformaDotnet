using System;
using System.Collections.Generic;

namespace code.Collection.Content {
    public class Pilha {
        public void Run() {
            var stack = new Stack<char>();
            while(true) {
                Console.Write("Elemento: ");
                var element = Console.ReadLine();

                if(string.IsNullOrEmpty(element)){
                    break;
                }
                char first = element[0];
                stack.Push(first);
            }

            foreach(char item in stack) {
                Console.WriteLine($"=> {item}");
            }
        }        
    }
}