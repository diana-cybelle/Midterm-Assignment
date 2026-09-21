using System;
using System.Collections.Generic;

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Problem4
{
    static void Main()
    {
        Stack<Operation> operationHistory = new Stack<Operation>();
        operationHistory.Push(new Operation
        {
            Action = "Added",
            StudentNumber = "2026-0001",
            StudentName = "Juan"
        });

        operationHistory.Push(new Operation
        {
            Action = "Added",
            StudentNumber = "2026-0002",
            StudentName = "Maria"
        });

        operationHistory.Push(new Operation
        {
            Action = "Updated",
            StudentNumber = "2026-0001",
            StudentName = "Juan"
        });

        operationHistory.Push(new Operation
        {
            Action = "Deleted",
            StudentNumber = "2026-0003",
            StudentName = "Pedro"
        });

        bool running = true;

        while (running)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("           OPERATION HISTORY");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ViewHistory(operationHistory);
                    break;

                case "2":
                    ViewLastOperation(operationHistory);
                    break;

                case "3":
                    RemoveLastOperation(operationHistory);
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

    static void ViewHistory(Stack<Operation> operationHistory)
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operations recorded.");
            return;
        }

        Console.WriteLine("OPERATION HISTORY");
        Console.WriteLine();

        Operation[] operations = operationHistory.ToArray();

        for (int i = operations.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(
                (operations.Length - i) + ". " +
                operations[i].Action + " " +
                operations[i].StudentName
            );
        }
    }

    static void ViewLastOperation(Stack<Operation> operationHistory)
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operations recorded.");
            return;
        }

        Operation op = operationHistory.Peek();

        Console.WriteLine(
            "Last Operation: " +
            op.Action + " " +
            op.StudentName
        );
    }

    static void RemoveLastOperation(Stack<Operation> operationHistory)
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operations recorded.");
            return;
        }

        operationHistory.Pop();

        Console.WriteLine("Last operation removed successfully!");
    }
}