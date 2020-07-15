using System;

namespace usingDelegate.Concept {
    public delegate void Del(string message);
    public class DelDelegate {
        private Del handler {get;set;}        
        public DelDelegate() {
            handler = DelegateMethod;            
        }
        public void Run() {
            Console.Write("Escreva uma mensagem: ");
            var message = Console.ReadLine();
            Console.WriteLine("Invocando o delegate");
            handler.Invoke(message);

            Console.WriteLine("---------------------");
            Console.Write("Informe o numero 1:");
            var num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o numero 2:");
            var num2 = Convert.ToInt32(Console.ReadLine());

            SumNumberPrintResult(num1,num2,handler);
        }
        
        public void DelegateMethod(string message) {
            Console.WriteLine(message);
        }

        public void SumNumberPrintResult(int number1, int number2, Del callback) {
            var result = number1 + number2;
            callback($"O resultado é {result}");
        }        
    }
}