using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.ViewModels
{
    public class DepartmentView
    {
        [Required]
        public string Dep_name { get; set; }
        public string Description { get; set; }
    }
}
