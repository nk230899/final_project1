using final_project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public interface IEmployeeRepsoitory
    {
        IEnumerable<Employee> GetEmployees();
        void DeleteEmployee(int EId);
        void AddEmployee(EmployeeView employee);
        void EditEmployee(EmployeeView employee,int id);
       
    }
}
