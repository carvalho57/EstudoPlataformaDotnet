using System;

namespace usingDelegate.Concept {
    delegate void CustomMessage(string message);
    public class MultiCastDel {
        private CustomMessage Handler {get;set;}
        private Greetings Gretting {get;set;}

        public MultiCastDel(){
            Gretting = new Greetings();
            Handler  += Gretting.Hello;
            Handler  += Gretting.Goodbye;
            Handler  += Gretting.SaySomething;
        }
        
        public void Run() {
            Handler.Invoke("Gabriel");
        }
    }

    public class Greetings {
        public void Hello(string message) {
            Console.WriteLine($"Hello {message}");
        }
        public void Goodbye(string message) {
            Console.WriteLine($"Goodbye {message}");
        }
        public void SaySomething(string message) {
            Console.WriteLine($"Say Something {message}");
        }
    }
}
