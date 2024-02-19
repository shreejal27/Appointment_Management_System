using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    internal class Employee
    {
        private int employeeId;
        private string employeeName = string.Empty;
        private int emp_Age;


        public int EmployeeId
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get
            {
                return employeeName; //return the value
            }
            set  //assigns the value
            {
                employeeName = value.Length > 50 ? value[..50]: value; //custom logic can be included here
            }
        }
    }
}
