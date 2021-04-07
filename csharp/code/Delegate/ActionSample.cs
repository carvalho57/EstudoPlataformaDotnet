using System.Linq;
using System.Collections.Generic;
using System;

namespace code.Delegates
{
    public class FuncSample
    {
        private static List<int> numbers;

        public static void Run()
        {
            numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 }; 
            var numbersGreaterThanTree = numbers.Where(GreaterThanTree);
            // var numbersGreaterThanTree = numbers.Where(GreaterThanTree).ToList();
            foreach(var number in numbersGreaterThanTree)
                Console.WriteLine($"{number} ");
        }

        public static bool GreaterThanTree(int number) => number > 3;
        
    }
}