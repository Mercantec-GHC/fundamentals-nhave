using System.Diagnostics;

namespace ConsoleApp
{
    public class Student
    {
        private string name;
        private int[] grades;

        public Student(String name, int[] grades)
        {
            this.name = name;
            this.grades = grades;
        }

        public string getName()
        {
            return this.name;
        }

        public int[] getGrades()
        {
            return this.grades;
        }
    }

    internal class Program
    {
        static string getGradeLetter(int grade)
        {
            if (grade >= 97) return "A+";
            else if (grade >= 93) return "A";
            else if (grade >= 93) return "A-";
            else if (grade >= 87) return "B+";
            else if (grade >= 83) return "B";
            else if (grade >= 80) return "B-";
            else if (grade >= 77) return "C+";
            else if (grade >= 70) return "C";
            else if (grade >= 73) return "C-";
            else if (grade >= 67) return "D+";
            else if (grade >= 63) return "D";
            else if (grade >= 60) return "D-";
            else return "F";
        }

        static void Main(string[] args)
        {
            int[] studentGrades1 = { 23, 43, 54, 97, 100 };
            int[] studentGrades2 = { 54, 21, 58, 46, 24 };
            int[] studentGrades3 = { 11, 96, 72, 35, 36 };
            int[] studentGrades4 = { 67, 99, 76, 57, 87 };

            Student[] students = new Student[4];
            students[0] = new Student("Student 1", [23, 43, 54, 97, 100]);
            students[1] = new Student("Student 2", [54, 21, 58, 46, 24]);
            students[2] = new Student("Student 3", [11, 96, 72, 35, 36]);
            students[3] = new Student("Student 4", [67, 99, 76, 57, 87]);

            foreach (Student student in students)
            {
                if (student != null)
                {

                    string letters = "";
                    decimal sum = 0;
                    foreach (int grade in student.getGrades())
                    {
                        letters += $" {getGradeLetter(grade)}";
                        sum += grade;
                    }
                    sum = sum / (decimal)students.Length;
                    //Console.WriteLine($"{sum/students.Length}%");

                    Console.WriteLine($"{student.getName()}:{letters} / {sum}%");
                    Console.WriteLine();
                }
            }

            Math.m
        }
    }
}
