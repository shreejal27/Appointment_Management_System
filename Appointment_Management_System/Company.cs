using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    internal class Company
    {
        private int companyId;
        private string companyName = string.Empty;
        private string companyLocation = string.Empty;
        private string companyDescription = string.Empty;


        public int CompanyId
        {
            get;
            set;
        }
        public string CompanyName
        {
            get
            {
                return companyName; 
            }
            set
            {
                companyName = value.Length > 50 ? value[..50] : value; 
            }
        }
        public string? CompanyLocation
        {
            get; set;
        }

        public string? CompanyDescription
        {
            get; set;
        }

    }
}
