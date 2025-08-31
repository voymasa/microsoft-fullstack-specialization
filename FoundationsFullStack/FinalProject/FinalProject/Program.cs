
// See https://aka.ms/new-console-template for more information
using FinalProject.Managers;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool exit = false; // used to control the main loop for single exit point

            Console.WriteLine("Welcome to the Student Management System");
            Console.WriteLine();
            // create menu for user interaction
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Assign Grades");
                Console.WriteLine("3. Calculate Averages");
                Console.WriteLine("4. Display Student Grades");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        string id = Console.ReadLine() ?? "";
                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine() ?? "";
                        manager.AddStudent(id, name);
                        break;
                    case "2":
                        // handle case where no students exist
                        if (manager.Students.Count == 0)
                        {
                            Console.WriteLine("No students available. Please add a student first.");
                            break;
                        }
                        Console.Write("Enter Student ID: ");
                        string studentId = Console.ReadLine() ?? "";
                        Console.Write("Enter Subject: ");
                        string subject = Console.ReadLine() ?? "";
                        Console.Write("Enter Score (0-100): ");
                        if (double.TryParse(Console.ReadLine(), out double score))
                        {
                            manager.GradeSubject(studentId, subject, score);
                        }
                        else
                        {
                            Console.WriteLine("Invalid score input.");
                        }
                        break;
                    case "3":
                        manager.CalculateGradeAverages();
                        break;
                    case "4":
                        manager.DisplayStudentRecords();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Thank you for using my program.\nExiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}