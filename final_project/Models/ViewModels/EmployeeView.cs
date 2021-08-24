using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.ViewModels
{
    public class EmployeeView
    {
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public DateTime dob { get; set; }

        public string email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public int DepId { get; set; }

        [Required]
        public string password { get; set; }
    }
}
