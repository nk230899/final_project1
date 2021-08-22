using final_project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        void AddDepartment(DepartmentView department);
        void DeleteDepartment(int DepId);
        void EditDepartment(DepartmentView department,int DepId);

        Department GetDepartment(int DepId);

    }
}
