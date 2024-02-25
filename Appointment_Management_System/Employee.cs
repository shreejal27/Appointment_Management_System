using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    public class Employee
    {
        private static List<Employee> EmployeeList = new List<Employee>();
        private static List<string> EmployeePosition = new List<string>();

        public List<DateTime> appointmentDates = new List<DateTime>();

        private int id;
        private string name;
        private string email;
        private string position;
        private string company;
        private string slots = string.Empty;

        public Employee(int Id, string Name, string Email, string Position, string Company)
        {
            id = Id;
            name = Name;
            email = Email;
            position = Position;
            company = Company;
            EmployeeList.Add(this);
        }

        public List<DateTime> AppointmentDates
        {
            get { return appointmentDates; }
            set { appointmentDates = value; }
        }

        public void AddAppointmentDate(DateTime appointmentDate)
        {
            appointmentDates.Add(appointmentDate);
        }

        public void RemoveAppointmentDate(DateTime appointmentDate)
        {
            appointmentDates.Remove(appointmentDate);
        }

        public static void AddEmployee()
        {

            int id = EmployeeList.Count;
            id++;
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your position: ");
            string position = Console.ReadLine();
            Console.Write("Select your company: ");
            Company.ViewCompanies();
            int companyIndex = int.Parse(Console.ReadLine());
            string companyName = Company.ValidateCompany(companyIndex);
            if (companyName != string.Empty)
            {
                Employee employee = new(id, name, email, position, companyName);
            }
            else
            {
                Console.WriteLine("Please choose correct company");
            }
        }

        public static void ViewEmployee()
        {
            Console.WriteLine("List of Registered Employees:");
            Console.WriteLine();
            Console.WriteLine("Id\t Name\t Email \t Position \t Company");
            foreach (var employee in EmployeeList)
            {
                Console.WriteLine($"{employee.id}\t {employee.name}\t {employee.email} \t {employee.position}\t {employee.company}");
            }
        }

        public static bool SearchEmployee(string name, string email)
        {
            foreach (var Employee in EmployeeList)
            {
                if (Employee.name == name && Employee.email == email)
                    return true;
            }
            return false;
        }

        public static bool ValidateAppointmentValues(string name, DateTime appointmentDate)
        {
            foreach (var Employee in EmployeeList)
            {
                if (Employee.name == name)
                {

                    foreach (var date in Employee.appointmentDates)
                    {
                        if (date == appointmentDate)
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }
        //public string Slots
        //{
        //    get
        //    {
        //        return slots; //return the value
        //    }
        //    set  //assigns the value
        //    {
        //        slots = value.Length > 50 ? value[..50] : value; //custom logic can be included here
        //    }
        //}

        public static string CheckAllPositionsInCompany(string userSelectedCompany)
        {

            foreach (var Employee in EmployeeList)
            {
                if (Employee.company == userSelectedCompany)
                    EmployeePosition.Add(Employee.position);
            }
            if (EmployeePosition.Count > 0)
            {

                foreach (var Position in EmployeePosition.Distinct())
                {
                    Console.WriteLine(Position);
                }
                Console.WriteLine("Select a position");
                string userSelectPosition = Console.ReadLine();

                if (EmployeePosition.Contains(userSelectPosition))
                {
                    return userSelectPosition;

                }
                else
                {
                    Console.WriteLine("Invalid position. Please select from the list.");
                    return CheckAllPositionsInCompany(userSelectedCompany);
                }
            }
            else
            {
                Console.WriteLine("There are no employees/positions in this company !!");
                Company.SelectCompany();
                return "";
            }

        }

        public static void ViewEmployeesFromPosition(string companyname, string position)
        {
            Console.WriteLine($" Viewed Company: {companyname}");
            Console.WriteLine($" Viewed Position: {position}");
            Console.WriteLine("All Employee from the above position");
            foreach (var Employee in EmployeeList)
            {
                if (Employee.company == companyname && Employee.position == position)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{Employee.name}");
                    Console.WriteLine();
                    if (Employee.appointmentDates.Count > 0)
                    {
                        Console.WriteLine("Available Appointment Dates:");
                        Console.WriteLine();
                        foreach (var appointmentDate in Employee.appointmentDates)
                        {
                            Console.WriteLine($" {appointmentDate.ToString("yyyy-MM-dd hh:mm")}");

                        }
                    }
                    else
                    {
                        Console.WriteLine("All Appointment Dates are booked for " + Employee.name);
                    }
                    Console.WriteLine();
                }

            }

            Console.WriteLine();
            Console.WriteLine("Do you want to book an appointment? (y/n)");
            string appointmentResult = Console.ReadLine();
            while (appointmentResult != "y" && appointmentResult != "Y" && appointmentResult != "n" && appointmentResult != "N")
            {
                Console.WriteLine("Choose between y/n !");
                appointmentResult = Console.ReadLine();
            }

            if (appointmentResult == "y" || appointmentResult == "Y")
            {
                BookAppointment();
            }
            else
            {
                Console.WriteLine("Going Back");
                Company.ViewCompanies();
                Company.SelectCompany();
            }

        }

        public static void BookAppointment()
        {
            Console.WriteLine("Write the name of person: ");
            string appointmentSelectedEmployee = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(appointmentSelectedEmployee))
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
                BookAppointment(); 
                return;
            }
            DateTime appointmentSelectedDate;
            Console.WriteLine("Select the appointment date from above options: YYYY/MM/DD HH:MM");

            if (!DateTime.TryParse(Console.ReadLine(), out appointmentSelectedDate))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                BookAppointment(); 
                return;
            }

            // Client.BookAppointment(appointmentSelectedEmployee, appointmentSelectedDate);

            bool appointmentResult = ValidateAppointmentValues(appointmentSelectedEmployee, appointmentSelectedDate);

            if (appointmentResult)
            {
                ConfirmAppointment(appointmentSelectedEmployee, appointmentSelectedDate);
            }
            else
            {
                Console.WriteLine("Please check your input and try again");
                BookAppointment();
            }
        }

        public static int EmailFlag;
        public static void ConfirmAppointment(string employeeName, DateTime appDate)
        {
            Console.WriteLine("Confirm Appointment ? (y/n)");
            char a = char.Parse(Console.ReadLine());
            if (a == 'y')
            {
                foreach (var Employee in EmployeeList)
                {
                    if (Employee.name == employeeName)
                    {
                        foreach (var appointmentDate in Employee.appointmentDates.ToList())
                        {
                            if (appDate == appointmentDate)
                            {
                                Employee.appointmentDates.Remove(appointmentDate);
                                Company.SendEmailEmployee(Employee.name);
                                EmailFlag = 1;

                            }
                        }
                    }


                }
            }
            else if (a == 'n')
            {
                Console.WriteLine();
                EmailFlag = 0;
            }
            else
            {
                Console.WriteLine();
                EmailFlag = 0;
            }
        }

    }
}
