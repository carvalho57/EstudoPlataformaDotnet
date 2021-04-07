using System;
using System.Collections.Generic;

namespace code
{

    public class IteratorSample
    {
        public static void Run()
        {
            ForeachExamples.ExampleOne();

            ForeachExamples.ExampleForEachUsingIteratorMethod();

            foreach (var item in IteratorMethods.GetSingleDigitNumbers())
                Console.WriteLine(item);

            foreach (var item in IteratorMethods.GetSingleDigitNumbersV2())
                Console.WriteLine(item);

            foreach (var item in IteratorMethods.GetSingleDigitNumbersAndNumbersOver100())
                Console.WriteLine(item);
        }
    }
}