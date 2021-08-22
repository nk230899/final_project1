using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Compliance
    {
        public int RLId { get; set; }
        public int EId { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
