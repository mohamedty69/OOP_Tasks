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
        public void returnTopStudent(int count)
        {
            var dict = new Dictionary<double, string>();
            var l = new List<double>();
            foreach (var student in students)
            {
                dict.Add(student.calculateAverageGrade(), student.stuedentName);
                l.Add(student.calculateAverageGrade());
            }
            l.Sort();
            l.Reverse();
            if (count > l.Count)
            {
                Console.WriteLine("Invalid Number");
            }
            else
            {
                for (int i = 0; i < count; i++)
                    {
                        foreach (var kvp in dict)
                        {
                            if (kvp.Key == l[i])
                            {
                                Console.WriteLine($"{kvp.Value} : {kvp.Key}");
                            }
                        }
                }
            }
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
