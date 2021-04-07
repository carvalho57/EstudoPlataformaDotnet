using System;
using System.Collections.Generic;

namespace code
{

    public static class ForeachExamples
    {
        public static void ExampleOne()
        {
            var collection = new List<string>
            {
                "Hello",
                "World",
                "Iterators",
                "are",
                "awesome"
            };
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void ExampleForEach()
        {
            var collection = new List<string>
            {
                "Hello",
                "World",
                "Iterators",
                "are",
                "awesome"
            };
            IEnumerator<string> enumerator = collection.GetEnumerator();
            var item = default(string);
            while (enumerator.MoveNext())
            {
                item = enumerator.Current;
                Console.WriteLine(item.ToString());
            }
        }

        public static void ExampleForEachUsingIteratorMethod()
        {
            var collection = IteratorMethods.GetSingleDigitNumbers();
            IEnumerator<int> enumerator = collection.GetEnumerator();
            var item = default(int);
            while (enumerator.MoveNext())
            {
                item = enumerator.Current;
                Console.WriteLine(item.ToString());
            }
        }
    }
}