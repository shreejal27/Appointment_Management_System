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
using System.Diagnostics.Metrics;

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

//calling the main menu at the start
mainMenu();

//main menu method
static void mainMenu()
{

    bool flag;
do
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1 => Login");
    Console.WriteLine("2 => Register");
    Console.WriteLine("3 => View Clients");
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
                Console.WriteLine("Login");
                login();
                break;

            case 2:
                Console.WriteLine("Register");
                register();
                break;

            case 3:
                 Console.WriteLine("viewing");
                    Client.ViewClients();
                    mainMenu();
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
}

//signIn method
static void login()
{
    Console.WriteLine("Sign In selected");
    bool loginFlag;
    do
    {
        Console.WriteLine("Sign In As:");
        Console.WriteLine("1 => Employee");
        Console.WriteLine("2 => Client");
        Console.WriteLine("7 => Go To Main Menu");
        Console.WriteLine("9 => To exit the application");
        Console.WriteLine();

        Console.Write("Your Option: ");

        var optionInput = Console.ReadLine();

        if (int.TryParse(optionInput, out int option))
        {
            loginFlag = false;
            Console.WriteLine();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Signed In As an Employee");
                    break;

                case 2:
                    Console.WriteLine("Enter Your Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Your Email");
                    string email = Console.ReadLine();
                    bool loginResult = Client.SearchClient(name, email);
                    if (loginResult)
                    { 
                    Console.WriteLine("Signed In As a Client");
                    }
                    else
                    {
                        Console.WriteLine("Login Failed. Try Again");
                    }
                    break;

                case 7:
                    Console.WriteLine("Going Back");
                    mainMenu();
                    break;

                case 9:
                    Console.WriteLine("\tExiting the application ...");
                    Console.WriteLine();
                    return;

                default:
                    loginFlag = true;
                    Console.WriteLine("\tPlease choose from above options only.");
                    Console.WriteLine();
                    break;
            }
        }
        else
        {
            loginFlag = true;
            Console.WriteLine();
            Console.WriteLine("\tError !!! Please Input Integers Only");
            Console.WriteLine();

        }
    } while (loginFlag);
}

//register method
static void register()
{
    Console.WriteLine("Register Selected");
    bool registerFlag;
    do
    {
        Console.WriteLine("Register As:");
        Console.WriteLine("1 => Employee");
        Console.WriteLine("2 => Client");
        Console.WriteLine("7 => Go to Main Menu");
        Console.WriteLine("9 => To exit the application");
        Console.WriteLine();

        Console.Write("Your Option: ");

        var optionInput = Console.ReadLine();

        if (int.TryParse(optionInput, out int option))
        {
            registerFlag = false;
            Console.WriteLine();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Registered As an Employee");
                    Employee employee = new Employee(1,"shree", "shree@gmail.com", "IT", "Aloi");
                    break;

                case 2:
                    Console.WriteLine("Registered As a Client");
                    Client.AddClient();
                    mainMenu();
                    break;

                case 7:
                    Console.WriteLine("Going Back");
                    mainMenu();
                    break;

                case 9:
                    Console.WriteLine("\tExiting the application ...");
                    Console.WriteLine();
                    return;

                default:
                    registerFlag = true;
                    Console.WriteLine("\tPlease choose from above options only.");
                    Console.WriteLine();
                    break;
            }
        }
        else
        {
            registerFlag = true;
            Console.WriteLine();
            Console.WriteLine("\tError !!! Please Input Integers Only");
            Console.WriteLine();

        }
    } while (registerFlag);
}


