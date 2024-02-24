using System;
using System.Collections.Generic;
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
            foreach (var Position in EmployeePosition.Distinct())
            {
                Console.WriteLine(Position);
            }
            Console.WriteLine("Select a position");
            string userSelectPosition = Console.ReadLine();
            return userSelectPosition;
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
                    Console.Write($" {Employee.name}");
                    Console.Write("Available Appointment Dates:");
                    foreach (var appointmentDate in Employee.appointmentDates)
                    {
                        Console.Write($" {appointmentDate.ToString("yyyy-MM-dd hh:mm")}");
                    }
                    Console.WriteLine();
                }

            }

            Console.WriteLine();
            Console.WriteLine("Do you want to book an appointment? (y/n)");
            char appointmentResult = char.Parse(Console.ReadLine());
            if (appointmentResult == 'y')
            {
                Console.WriteLine("Write the name of person: ");
                string appointmentSelectedEmployee = Console.ReadLine();
                Console.WriteLine("Select the appointment date from above options: MM/dd/yyyy HH:mm:ss");
                DateTime appointmentSelectedDate = DateTime.Parse(Console.ReadLine());
                Client.BookAppointment(appointmentSelectedEmployee, appointmentSelectedDate);
            }

        }

        public static bool ConfirmAppointment(string employeeName, DateTime appDate)
        {
            Console.WriteLine("Confirm Appointment ? (y/n)");
            char a = char.Parse(Console.ReadLine());
            if (a == 'y')
            {
                try
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
                                    return true;
                                }
                            }
                        }

                    }
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message); 
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

    }
}
