using System;

namespace code.Events 
{
    public class Boomer 
    {
        public event EventHandler Boom;
        public void Start()
        {
            OnBoom();            
        }
        protected virtual void OnBoom()
        {
            Boom?.Invoke(this, EventArgs.Empty);
        }
    }

    public class BoomerSample
    {
        public static void Run()
        {
            var boomer = new Boomer();
            boomer.Boom += boomer_Boom;
            boomer.Start();
        }

        private static void boomer_Boom(object sender, EventArgs args)
        {
            Console.WriteLine("Boom");
        }
    }
}