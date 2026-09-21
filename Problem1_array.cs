using System;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Problem1
{
    static void Main()
    {
        Student[] students = new Student[10];
        int studentCount = 0;

        bool running = true;

        while (running)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("        STUDENT RECORD MANAGEMENT");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine()?? "";
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent(students, ref studentCount);
                    break;
                case "2":
                    DisplayAll(students, studentCount);
                    break;
                case "3":
                    SearchStudent(students, studentCount);
                    break;
                case "4":
                    UpdateStudent(students, studentCount);
                    break;
                case "5":
                    DeleteStudent(students, ref studentCount);
                    break;
                case "6":
                    Console.WriteLine("Program exited.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 to 6.");
                    break;
            }

            Console.WriteLine();
        }
    }
    static int FindIndex(Student[] students, int studentCount, string studentNumber)
    {
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].StudentNumber == studentNumber)
            {
                return i;
            }
        }
        return -1;
    }

    static void AddStudent(Student[] students, ref int studentCount)
    {
        if (studentCount >= students.Length)
        {
            Console.WriteLine("Cannot add more students. Maximum of 10 records reached.");
            return;
        }

        Student s = new Student();

        Console.Write("Enter Student Number: ");
        s.StudentNumber = Console.ReadLine()??"";

        if (FindIndex(students, studentCount, s.StudentNumber) != -1)
        {
            Console.WriteLine();
            Console.WriteLine("A student with that Student Number already exists.");
            return;
        }

        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine()??"";

        Console.Write("Enter Program: ");
        s.Program = Console.ReadLine()??"";

        s.YearLevel = ReadYearLevel();

        students[studentCount] = s;
        studentCount++;

        Console.WriteLine();
        Console.WriteLine("Student added successfully!");
    }

    static int ReadYearLevel()
    {
        while (true)
        {
            Console.Write("Enter Year Level: ");
            string input = Console.ReadLine()??"";
            int year;

            if (int.TryParse(input, out year) && year >= 1 && year <= 4)
            {
                return year;
            }

            Console.WriteLine("Invalid year level. Enter 1, 2, 3, or 4.");
        }
    }

    static void PrintStudent(Student s)
    {
        Console.WriteLine("Student Number: " + s.StudentNumber);
        Console.WriteLine("Name: " + s.Name);
        Console.WriteLine("Program: " + s.Program);
        Console.WriteLine("Year Level: " + s.YearLevel);
    }

    static void DisplayAll(Student[] students, int studentCount)
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No student records to display.");
            return;
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("              STUDENT RECORDS");
        Console.WriteLine("==========================================");

        for (int i = 0; i < studentCount; i++)
        {
            PrintStudent(students[i]);
            Console.WriteLine();
        }
    }

    static void SearchStudent(Student[] students, int studentCount)
    {
        Console.Write("Enter Student Number to search: ");
        string target = Console.ReadLine()??"";
        Console.WriteLine();

        int index = FindIndex(students, studentCount, target);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("Student found!");
        PrintStudent(students[index]);
    }

    static void UpdateStudent(Student[] students, int studentCount)
    {
        Console.Write("Enter Student Number to update: ");
        string target = Console.ReadLine()??"";
        Console.WriteLine();

        int index = FindIndex(students, studentCount, target);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("Current record:");
        PrintStudent(students[index]);
        Console.WriteLine();

        Console.Write("Enter New Name: ");
        students[index].Name = Console.ReadLine()??"";

        Console.Write("Enter New Program: ");
        students[index].Program = Console.ReadLine()??"";

        students[index].YearLevel = ReadYearLevel();

        Console.WriteLine();
        Console.WriteLine("Student updated successfully!");
    }

    static void DeleteStudent(Student[] students, ref int studentCount)
    {
        Console.Write("Enter Student Number to delete: ");
        string target = Console.ReadLine()??"";
        Console.WriteLine();

        int index = FindIndex(students, studentCount, target);

        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        for (int i = index; i < studentCount - 1; i++)
        {
            students[i] = students[i + 1];
        }

        students[studentCount - 1] = new Student();
        studentCount--;

        Console.WriteLine("Student deleted successfully!");
    }
}