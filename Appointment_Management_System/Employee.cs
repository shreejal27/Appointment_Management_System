using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    internal class Employee
    {
        private int id;
        private string name;
        private string email;
        private string position;
        private string company;
      //  private string slots = string.Empty;

        public Employee(int Id, string Name, string Email, string Position, string Company)
        {
            id = Id;
            name = Name;
            email = Email;
            position = Position;
            company = Company;
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
