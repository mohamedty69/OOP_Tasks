using Stuent_Grade_Book;
using System;
using System.Collections.Concurrent;
namespace StudentGradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a gradebook
            var gradeBook = new GradeBook("Computer Science 101");

            // Create students
            var student1 = new Student("S001", "Alice Johnson", "alice@school.com");
            var student2 = new Student("S002", "Bob Smith", "bob@school.com");
            var student3 = new Student("S003", "Charlie Brown", "charlie@school.com");

            // Add grades for students
            student1.addGrade("Math", 95.0);
            student1.addGrade("English", 88.0);
            student1.addGrade("Science", 92.0);

            student2.addGrade("Math", 78.0);
            student2.addGrade("English", 85.0);
            student2.addGrade("Science", 80.0);

            student3.addGrade("Math", 90.0);
            student3.addGrade("English", 92.0);
            student3.addGrade("Science", 89.0);

            gradeBook.addStudent(student1);
            gradeBook.addStudent(student2);
            gradeBook.addStudent(student3);

            gradeBook.displayAllstudents();
            Console.WriteLine();
            Console.WriteLine("Class Average: " + gradeBook.getClassAverage());
            Console.WriteLine();
            gradeBook.GetTopStudents(2);
            Console.WriteLine();
            student1.getStudentInfo();
            Console.WriteLine();
            var res = gradeBook.GetTopStudents(1);
            Console.WriteLine($"Top Student: {res[0].stuedentName} with Average Grade: {res[0].calculateAverageGrade()}");

        }
    }
}