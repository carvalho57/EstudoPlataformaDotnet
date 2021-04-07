using System;
using System.Linq;
using System.Collections.Generic;


namespace code.LinqPark
{
    public class LinqSample
    {
        private static List<Course> Courses;
        private static List<Student> Students;
        static LinqSample()
        {
            var so = new Course("Sistemas Operacionais");
            var ed = new Course("Estrutura de dados");
            Courses = new List<Course>() { so, ed };
            Students = new List<Student>()
            {
                new Student("Jose", so.Id),
                new Student("Carlos",so.Id),
                new Student("Amanda", so.Id),
                new Student("Leandro", ed.Id),
                new Student("Carol",ed.Id),
                new Student("Bruna",ed.Id)
            };
        }
        public static void Run()
        {
            Console.WriteLine("\nWhere Clause");
            WhereClause();
            Console.WriteLine("\nJoin Clause");
            JoinClause();
            Console.WriteLine("\nOrderBy Clause");
            OrderByClause();
        }

        private static void WhereClause()
        {
            Console.WriteLine("Apenas estudandes de Sistemas Operacionais");
            var studentSO = from student in Students
                            join course in Courses on student.CourseId equals course.Id
                            where course.Name == "Sistemas Operacionais"
                            select student.Name;
            foreach (var student in studentSO)
                Console.WriteLine($"Estudante: {student}");
        }
        private static void JoinClause()
        {
            Console.WriteLine("Estudantes e o nome do curso que eles fazem");
            var studentsCourse = from student in Students
                                 join course in Courses on student.CourseId equals course.Id
                                 select new { student = student.Name, course = course.Name };
            foreach (var studentCourse in studentsCourse)
                Console.WriteLine($"Estudante: {studentCourse.student} Curso: {studentCourse.course}");
        }

        private static void OrderByClause()
        {
            Console.WriteLine("Estudantes em orderm alfabetica");
            var orderedStudents = from student in Students
                                  orderby student.Name
                                  select student.Name;
            foreach (var student in orderedStudents)
                Console.WriteLine($"Estudante: {student}");

            WhereClause();
        }
    }
}