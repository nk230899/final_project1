using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Employee
    {
        public int Eid { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime dob { get; set; }

        public string email { get; set; }
        public string PhoneNumber { get; set; }

        public int DepId { get; set; }
    }
}
