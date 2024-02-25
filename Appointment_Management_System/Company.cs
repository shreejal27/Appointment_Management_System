using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            Console.WriteLine("\t\tList of Registered Companies");
            Console.WriteLine();
            Console.WriteLine("\t------------------------------------------------");
            Console.WriteLine("\t Id  |  Name   |  Location   |  Description");
            Console.WriteLine("\t------------------------------------------------");
            foreach (var company in CompanyList)
            {
                Console.WriteLine(String.Format("\t {0,-3} | {1,-7} | {2,-11} | {3,-20}", company.Id, company.Name, company.Location, company.Description));
            }
            Console.WriteLine("\t------------------------------------------------");
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

        //to view a specific company by user
        public static void SelectCompany()
        {
            bool counter = true;
            do
            {

                Console.WriteLine("Choose a company you want to view");
                int userSelectedCompany = int.Parse(Console.ReadLine());
                string userSelectedCompanyName = ValidateCompany(userSelectedCompany);


                if (userSelectedCompanyName != "")
                {
                    Console.WriteLine($"You selected {userSelectedCompanyName}");
                    string userSelectedPosition = Employee.CheckAllPositionsInCompany(userSelectedCompanyName);

                    Employee.ViewEmployeesFromPosition(userSelectedCompanyName, userSelectedPosition);
                    counter = false;

                }
                else
                {
                    Console.WriteLine("PLease select valid company");
                }
            } while (counter);
        }

        public static void SendEmailEmployee(string employeeName)
        {
            //string fromMail = "shreejal27@gmail.com";
            //string fromPassword = "vvssfwtuqgwyugzl";

            //MailMessage message = new MailMessage();
            //message.From = new MailAddress(fromMail);
            //message.Subject = "Appointment Booked";
            //message.To.Add(new MailAddress("vipervalorant27@gmail.com"));
            //message.Body = "<html><body>This is from Console Application. This is for Employee mail send by Company </body><html>";
            //message.IsBodyHtml = true;

            //var smtpClient = new SmtpClient("smtp.gmail.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential(fromMail, fromPassword),
            //    EnableSsl = true,
            //};

            //smtpClient.Send(message);
            Console.WriteLine("Email Sent to " + employeeName);
        }
        public static void SendEmailClient(string clientName)
        {
            //string fromMail = "shreejal27@gmail.com";
            //string fromPassword = "vvssfwtuqgwyugzl";

            //MailMessage message = new MailMessage();
            //message.From = new MailAddress(fromMail);
            //message.Subject = "Appointment Booked";
            //message.To.Add(new MailAddress("vipervalorant27@gmail.com"));
            //message.Body = "<html><body>This is from Console Application. This is for Client mail send by Company </body><html>";
            //message.IsBodyHtml = true;

            //var smtpClient = new SmtpClient("smtp.gmail.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential(fromMail, fromPassword),
            //    EnableSsl = true,
            //};

            //smtpClient.Send(message);
            Console.WriteLine("Email Sent to " + clientName);
        }

    }
}
