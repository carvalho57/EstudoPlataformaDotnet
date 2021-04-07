using System.Collections.Generic;
using System.Linq;
using System;

namespace code.LinqPark
{
    public class LinqJoinSample
    {
        private static List<Person> People { get; set; }
        private static List<Pet> Pets { get; set; }
        static LinqJoinSample()
        {
            var magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            var terry = new Person { FirstName = "Terry", LastName = "Adams" };
            var charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            var arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            People = new List<Person> { magnus, terry, charlotte, arlene };
            Pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };
        }
        public static void Run()
        {
            InnerJoin();
        }

        private static void InnerJoin()
        {
            var query = from person in People
                        join pet in Pets on person equals pet.Owner
                        select new { OwnerName = person.FirstName, PetName = pet.Name };

            foreach (var ownerAndPet in query)
            {
                Console.WriteLine($"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}");
            }
        }

        private static void GroupedJoin()
        {
            var query = from person in People
                        join pet in Pets on person equals pet.Owner into gj
                        select new { OwnerName = person.FirstName, Pets = gj };

            foreach (var v in query)
            {
                Console.WriteLine($"{v.OwnerName}:");
                foreach (Pet pet in v.Pets)
                    Console.WriteLine($"  {pet.Name}");
            }
        }

        private static void LeftOutJoin()
        {
            var query = from person in People
                        join pet in Pets on person equals pet.Owner into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };

            foreach (var v in query)
            {
                Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}");
            }
        }
    }
}