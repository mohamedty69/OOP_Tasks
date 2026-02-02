using System;
using System.Collections.Generic;
using System.Text;

namespace Stuent_Grade_Book
{
    public class Student
    {
        public string studentId { get; set; }
        public string stuedentName { get; set; }
        public string studentEmail { get; set; }
        public Dictionary<string,double> studentGrades { get; set; }
        public Student(string id, string name, string email)
        {
            studentId = id;
            stuedentName = name;
            studentEmail = email;
            this.studentGrades = new Dictionary<string, double>();
        }
        public void addGrade(string subject, double grade)
        {
            studentGrades.Add(subject, grade);
        }
        public void returnGrade(string subject) {
            foreach(var item in studentGrades)
            {
                if (item.Key == subject)
                {
                    Console.WriteLine($"The grade for {subject} is {item.Value}");
                }
            }
        }
        public double calculateAverageGrade()
        {
            var length = studentGrades.Count;
            var total = 0.0;
            var average = 0.0;
            foreach (var item in studentGrades)
            {
                total += item.Value;
            }
            average = total / length;
            return average;
        }
        public string getLetterGrade()
        {
            var average = calculateAverageGrade();
            if (average >= 90)
            {
                return "A";
            }
            else if (average >= 80)
            {
                return "B";
            }
            else if (average >= 70)
            {
                return "C";
            }
            else if (average >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }
        public void getStudentInfo()
        {
            Console.WriteLine($"ID: {studentId}"
                +$" Name: {stuedentName}"
                +$" Email: {studentEmail}"
                +$" Grades:");
            foreach(var item in studentGrades)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine($"Average: {calculateAverageGrade()} ({getLetterGrade()})");
        }
    }
}
