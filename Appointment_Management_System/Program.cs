/*
 Requirements of projects

    List of employees working in a company.
    Employees : start and end slots time, position.

   Problem Statement: Book an appointment

   How System will work: 
            Client wants to talk to a specific position of the company
            Check if there is the position in system, if yes list number of employees in the position, 
            Ask user to input time of appointment, take input time and check if slots are available within that time period,
                if no slots suggest the nearest time to user
                if open slots book the appointment with the employee
            Send the booked date via email to both employee and client

    Employee Class:
            Id                                                                                           
            Name
            Position
            Available slots
            
 */
using Appointment_Management_System;

//Application Heading

Console.Write(@"
 __      __   _                  
 \ \    / /__| |__ ___ _ __  ___ 
  \ \/\/ / -_) / _/ _ \ '  \/ -_)
   \_/\_/\___|_\__\___/_|_|_\___|            
");
Console.Write(@"
  _____    
 |_   _|__ 
   | |/ _ \
   |_|\___/
");
Console.Write(@"
    _                  _     _                 _     ___         _             
   /_\  _ __ _ __  ___(_)_ _| |_ _ __  ___ _ _| |_  / __|_  _ __| |_ ___ _ __  
  / _ \| '_ \ '_ \/ _ \ | ' \  _| '  \/ -_) ' \  _| \__ \ || (_-<  _/ -_) '  \ 
 /_/ \_\ .__/ .__/\___/_|_||_\__|_|_|_\___|_||_\__| |___/\_, /__/\__\___|_|_|_|
       |_|  |_|                                          |__/                  
");

Console.WriteLine();

Console.WriteLine("This is Appointment Management System");

//Employee e1  = new Employee();
//Employee e2  = new Employee();
//e1.EmployeeName = "Test";
//e2.EmployeeName = "Test1";
//Console.WriteLine($"Employee {e1.EmployeeName}");
//Console.WriteLine($"Employee {e2.EmployeeName}");

    bool flag;
do
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1 => Sign In");
    Console.WriteLine("2 => Register");
    Console.WriteLine("9 => To exit the application");
    Console.WriteLine();

    Console.Write("Your Option: ");

    var optionInput = Console.ReadLine();

    if (int.TryParse(optionInput, out int option))
    {
        flag = false;
        Console.WriteLine();
        switch (option)
        {
            case 1:
                Console.WriteLine("Case 1 Selected");
                break;
            case 2:
                Console.WriteLine("Case 2 Selected");
                break;

            case 9:
                Console.WriteLine("\tExiting the application ...");
                Console.WriteLine();
                return;

            default:
                flag = true;
                Console.WriteLine("\tPlease choose from above options only.");
                Console.WriteLine();
                break;
        }
    }
    else
    {
        flag = true;
                Console.WriteLine();
        Console.WriteLine("\tError !!! Please Input Integers Only");
                Console.WriteLine();

    }
} while (flag);

