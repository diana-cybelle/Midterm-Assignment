using System;
using System.Collections.Generic;

class Problem2
{
    static void Main()
    {
        Dictionary<string, Student> students =
            new Dictionary<string, Student>();

        bool running = true;

        while (running)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("       STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent(students);
                    break;

                case "2":
                    SearchStudent(students);
                    break;

                case "3":
                    DisplayAll(students);
                    break;

                case "4":
                    Console.WriteLine("Program exited.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1 to 4.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddStudent(Dictionary<string, Student> students)
    {
        Console.Write("Enter Student Number: ");
        string studentNumber = Console.ReadLine() ?? "";

        if (students.ContainsKey(studentNumber))
        {
            Console.WriteLine("A student with that Student Number already exists.");
            return;
        }

        Student s = new Student();

        s.StudentNumber = studentNumber;

        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine() ?? "";

        Console.Write("Enter Program: ");
        s.Program = Console.ReadLine() ?? "";

        s.YearLevel = ReadYearLevel();

        students.Add(studentNumber, s);

        Console.WriteLine();
        Console.WriteLine("Student added successfully!");
    }

    static int ReadYearLevel()
    {
        while (true)
        {
            Console.Write("Enter Year Level: ");

            string input = Console.ReadLine() ?? "";

            int year;

            if (int.TryParse(input, out year) &&
                year >= 1 &&
                year <= 4)
            {
                return year;
            }

            Console.WriteLine("Invalid year level. Enter 1, 2, 3, or 4.");
        }
    }

    static void SearchStudent(Dictionary<string, Student> students)
    {
        Console.Write("Enter Student Number to search: ");
        string studentNumber = Console.ReadLine() ?? "";

        Console.WriteLine();

        if (students.TryGetValue(studentNumber, out Student student))
        {
            Console.WriteLine("Student Found!");
            Console.WriteLine("Student Number: " + student.StudentNumber);
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Program: " + student.Program);
            Console.WriteLine("Year Level: " + student.YearLevel);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DisplayAll(Dictionary<string, Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No student records to display.");
            return;
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("             STUDENT RECORDS");
        Console.WriteLine("==========================================");

        foreach (Student student in students.Values)
        {
            Console.WriteLine("Student Number: " + student.StudentNumber);
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Program: " + student.Program);
            Console.WriteLine("Year Level: " + student.YearLevel);
            Console.WriteLine();
        }
    }
}