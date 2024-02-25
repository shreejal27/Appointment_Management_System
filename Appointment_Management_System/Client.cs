using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Appointment_Management_System
{
    public class Client
    {
        private static List<Client> ClientList = new List<Client>();
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get; 
            set;
        }

        //public Client()
        //{   
        //    Id = 0;
        //    Name = string.Empty;
        //    Email = string.Empty;
        //    return;
        //}

        public Client (int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            ClientList.Add(this);
        }

       

        public static void ViewClients()
        {
            Console.WriteLine("List of Registered Clients:");
            foreach (var client in ClientList)
            {
                Console.WriteLine($"Id: {client.Id} Name: {client.Name}, Email: {client.Email} ");
            }
        }


        public static void AddClient()
        {

            int id = ClientList.Count;
            id++;
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Client client = new(id, name, email);

        }

        public static bool SearchClient(string name, string email)
        {
            foreach (var Client in ClientList)
            {
                if (Client.Name == name && Client.Email == email)
                    return true;
            }
                    return false;
        }

        public static void BookAppointment(string employeeName, DateTime appointmentDate)
        {
            Console.WriteLine("Book Appointment method Called");
            Console.WriteLine();
            Console.WriteLine(employeeName);
            Console.WriteLine(appointmentDate);

            bool appointmentResult = Employee.ValidateAppointmentValues(employeeName, appointmentDate);

            if (appointmentResult)
            {
                Employee.ConfirmAppointment(employeeName, appointmentDate);
            }
        }

    }
}
