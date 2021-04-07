using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace code
{
    public class Measurements
    {
        public Measurements() { }
        public Measurements(int hiTemp, int loTemp, double airPressure)
        {
            HiTemp = hiTemp;
            LoTemp = loTemp;
            AirPressure = airPressure;
        }

        public int HiTemp { get; set; }
        public int LoTemp { get; set; }
        public double AirPressure { get; set; }
    }
    public class DataSamples
    {
        private class Page
        {
            private readonly List<Measurements> pageData = new List<Measurements>();
            private readonly int startingIndex;
            private readonly int length;
            private bool dirty;
            private DateTime lastAccess;

            public Page(int startingIndex, int length)
            {
                this.startingIndex = startingIndex;
                this.length = length;
                lastAccess = DateTime.Now;

                // This stays as random stuff:
                var generator = new Random();
                for (int i = 0; i < length; i++)
                {
                    var m = new Measurements
                    {
                        HiTemp = generator.Next(50, 95),
                        LoTemp = generator.Next(12, 49),
                        AirPressure = 28.0 + generator.NextDouble() * 4
                    };
                    pageData.Add(m);
                }
            }
            public bool HasItem(int index) =>
                ((index >= startingIndex) &&
                (index < startingIndex + length));

            public Measurements this[int index]
            {
                get
                {
                    lastAccess = DateTime.Now;
                    return pageData[index - startingIndex];
                }
                set
                {
                    pageData[index - startingIndex] = value;
                    dirty = true;
                    lastAccess = DateTime.Now;
                }
            }

            public bool Dirty => dirty;
            public DateTime LastAccess => lastAccess;
        }

        private readonly int totalSize;
        private readonly List<Page> pagesInMemory = new List<Page>();

        public DataSamples(int totalSize)
        {
            this.totalSize = totalSize;
        }

        public Measurements this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Cannot index less than 0");
                if (index >= totalSize)
                    throw new IndexOutOfRangeException("Cannot index past the end of storage");

                var page = updateCachedPagesForAccess(index);
                return page[index];
            }
            set
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Cannot index less than 0");
                if (index >= totalSize)
                    throw new IndexOutOfRangeException("Cannot index past the end of storage");
                var page = updateCachedPagesForAccess(index);

                page[index] = value;
            }
        }

        private Page updateCachedPagesForAccess(int index)
        {
            foreach (var p in pagesInMemory)
            {   
                //Se eu tiver o item nessa pagina eu retorno
                if (p.HasItem(index))
                {
                    return p;
                }
            }
            //Caso não tenha, busco a pagina e adiciono no cache
            var startingIndex = (index / 1000) * 1000;
            var newPage = new Page(startingIndex, 1000);
            addPageToCache(newPage);
            return newPage;
        }

        private void addPageToCache(Page p)
        {
            //Se eu tiver mais de 4 paginas  na memoria
            if (pagesInMemory.Count > 4)
            {
                // remove oldest non-dirty page:
                var oldest = pagesInMemory
                    .Where(page => !page.Dirty)
                    .OrderBy(page => page.LastAccess)
                    .FirstOrDefault();
                // Note that this may keep more than 5 pages in memory
                // if too much is dirty
                if (oldest != null)
                    pagesInMemory.Remove(oldest);
            }
            //Adiciono a nova pagina
            pagesInMemory.Add(p);
        }
    }

    public class IndexDataSample 
    {
        public static void Run()
        {
            var sample = new DataSamples(8);
            sample[0] = new Measurements(50,60,1.5);
            sample[1] =  new Measurements(20,30,1.5);
            sample[2] =  new Measurements(20,30,1.5);
            sample[3] =  new Measurements(80,10,1.5);
            sample[4] = new Measurements(50,15,1.5);
            sample[5] = new Measurements(20,30,1.5);
            sample[6] = new Measurements(20,30,1.5);
            sample[7] = new Measurements(20,30,1.5);

            var people = new People(new Person[] {new Person("Jose"), new Person("Amanda"), new Person("Carlos")});
            Console.WriteLine($"Person 1: {people[0].Name}");
            Console.WriteLine($"Person 2: {people[1].Name}");
            Console.WriteLine($"Person 3: {people[2].Name}");
        }
    }

    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
    public class People
    {
        private readonly Person[] _people;
        public People(Person[] people)
        {
            _people = people;
        }
        public Person this[int index]
        {
            get
            {
                if(index < 0 & index >= _people.Length)
                    throw new ArgumentOutOfRangeException();
                return _people[index];
            }
        }
    }
}