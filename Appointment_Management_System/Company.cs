using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Appointment_Management_System
{
    public class Company
    {

        public int Id
        {
            get;
            set;
        }
        public string? Name
        {
            get;
            set;
        }
        public string? Location
        {
            get; set;
        }

        public string? Description
        {
            get; set;
        }

        public string? Email
        {
            get; set;
        }

        private static List<Company> CompanyList = new List<Company>();


        public Company(int id, string name, string location, string description, string email)
        {
            Id = id;
            Name = name;
            Location = location;
            Description = description;
            Email = email;
            CompanyList.Add(this);
        }
      
        public static void ViewCompanies()
        {
            Console.WriteLine("List of Registered Companies:");
            Console.WriteLine();
            Console.WriteLine("Id\t Name\t Location \t Description");
            foreach (var company in CompanyList)
            {
                Console.WriteLine($"{company.Id}\t {company.Name}\t {company.Location}\t {company.Description}");
            }
        }

        public static string ValidateCompany(int companyIndex)
        {
            foreach (var Company in CompanyList)
            {
                if (Company.Id == companyIndex)
                    return Company.Name;
            }
            return "";
        }

        public static void SelectCompany()
        {
            Console.WriteLine("Choose a company you want to view");
            int userSelectedCompany = int.Parse(Console.ReadLine());
            string userSelectedCompanyName= ValidateCompany(userSelectedCompany);
            if(userSelectedCompanyName != "")
            {
                Console.WriteLine($"You selected {userSelectedCompanyName}");
                string userSelectedPosition = Employee.CheckAllPositionsInCompany(userSelectedCompanyName);

                Employee.ViewEmployeesFromPosition(userSelectedCompanyName, userSelectedPosition);

               

            }
            else
            {
                Console.WriteLine("PLease select valid company");
            }
        }

    }
}
