using System;
using System.Collections.Generic;

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

class Problem3
{
    static void Main()
    {
        Queue<StudentRequest> requestQueue =
            new Queue<StudentRequest>();

        bool running = true;

        while (running)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("          STUDENT REQUEST QUEUE");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddRequest(requestQueue);
                    break;

                case "2":
                    ViewPendingRequests(requestQueue);
                    break;

                case "3":
                    ProcessRequest(requestQueue);
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
    static void AddRequest(Queue<StudentRequest> requestQueue)
    {
        StudentRequest request = new StudentRequest();

        Console.Write("Enter Student Number: ");
        request.StudentNumber = Console.ReadLine() ?? "";

        Console.Write("Enter Student Name: ");
        request.StudentName = Console.ReadLine() ?? "";

        Console.Write("Enter Request Type: ");
        request.RequestType = Console.ReadLine() ?? "";

        requestQueue.Enqueue(request);

        Console.WriteLine();
        Console.WriteLine("Request added successfully!");
    }
    static void ViewPendingRequests(
        Queue<StudentRequest> requestQueue)
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.");
            return;
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("             REQUEST QUEUE");
        Console.WriteLine("==========================================");

        int number = 1;

        foreach (StudentRequest request in requestQueue)
        {
            Console.WriteLine(
                number + ". " +
                request.StudentName + " - " +
                request.RequestType
            );

            number++;
        }
    }
    static void ProcessRequest(
        Queue<StudentRequest> requestQueue)
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests to process.");
            return;
        }

        StudentRequest request = requestQueue.Dequeue();

        Console.WriteLine(
            "Processing Request: " +
            request.StudentName +
            " - " +
            request.RequestType
        );

        Console.WriteLine();
        Console.WriteLine("Request processed successfully!");
    }
}