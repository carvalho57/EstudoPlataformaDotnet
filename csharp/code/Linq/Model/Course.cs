using System;

namespace code.LinqPark
{
    public class Course
    {
        public Course(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}