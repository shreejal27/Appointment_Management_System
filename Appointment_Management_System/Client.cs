using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    internal class Client
    {
        private int clientId;
        private string clientName = string.Empty;
        private int clientEmail;


        public int ClientId
        {
            get;
            set;
        }
        public string ClientName
        {
            get
            {
                return clientName; 
            }
            set  //assigns the value
            {
                clientName = value.Length > 50 ? value[..50] : value;
            }
        }

        public int ClientEmail
        {
            get; set;
        }
    }
}
