using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Appointment_Management_System
{
    internal class Company
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

        private static List<Company> CompanyList = new List<Company>();


        public Company(int id, string name, string location, string description)
        {
            Id = id;
            Name = name;
            Location = location;
            Description = description;
        }

        static Company()
        {
            Company c1 = new Company(1, "Aloi", "kuleshwor", "lorem");
            CompanyList.Add(c1);   
            Company c2 = new Company(2, "ABC", "balkhu", "motors");
            CompanyList.Add(c2);   
            Company c3 = new Company(3, "XYZ", "kalanki", "recruiting");
            CompanyList.Add(c3);      
            Company c4 = new Company(4, "Hello", "teku", "hospital");
            CompanyList.Add(c4);      
            Company c5 = new Company(3, "Samsu", "kalimati", "mobile");
            CompanyList.Add(c5);
            
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

    }
}
