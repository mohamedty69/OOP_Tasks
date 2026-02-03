using System;
using System.Collections.Generic;
using System.Text;

namespace Stuent_Grade_Book
{
    public class GradeBook
    {
        public string className { get; set; }
        public List<Student> students { get; set; }
        public GradeBook(string className)
        {
            this.className = className;
            this.students = new List<Student>();
        }
        public void addStudent(Student student)
        {
            students.Add(student);
        }
        public void removeStudent(string studentId)
        {
            foreach(var student in students)    
            {
                if (student.studentId == studentId)
                {
                    students.Remove(student);
                    break;
                }
            }
        }
        public double getClassAverage()
        {
            double total = 0.0;
            double average = 0.0;
            var len = students.Count;
            foreach(var student in students)
            {
                total += student.calculateAverageGrade();
            }
            return average = total / len;
        }
        public List<Student> GetTopStudents(int count)
        {
            if (count > students.Count || count <= 0)
                throw new ArgumentException("Invalid number");

            var sortedStudents = students
                .OrderByDescending(s => s.calculateAverageGrade())
                .ToList();

            var result = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                result.Add(sortedStudents[i]);
            }

            return result;
        }
        public void displayAllstudents()
        {
            foreach(var student in students)
            {
                student.getStudentInfo();
            }
        }
        public void returnStudentWithspaceficletter(string letter)
        {
            foreach(var student in students)
            {
                if (student.getLetterGrade() == letter)
                {
                    Console.WriteLine($"{student.stuedentName} : {student.getLetterGrade()}");
                }
            }
        }
    }
}
