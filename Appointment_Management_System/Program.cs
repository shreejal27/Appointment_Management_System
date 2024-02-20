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

Console.WriteLine("Hello, World!");
Console.WriteLine("This is Appointment Management System");

Employee e1  = new Employee();
Employee e2  = new Employee();
e1.EmployeeName = "Test";
e2.EmployeeName = "Test1";
Console.WriteLine($"Employee {e1.EmployeeName}");
Console.WriteLine($"Employee {e2.EmployeeName}");