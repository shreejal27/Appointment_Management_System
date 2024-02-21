using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    internal class Employee
    {
        private static List<Employee> EmployeeList = new List<Employee>();

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
             EmployeeList.Add(employee);
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
                if (Employee.Name == name && Employee.Email == email)
                    return true;
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


    }
}
