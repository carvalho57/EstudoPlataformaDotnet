using System;

namespace code.LinqPark
{
    public class Student
    {
        public Student(string name, Guid id)
        {
            Name = name;
            CourseId = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
}