using final_project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using System.Data;

namespace final_project.Models.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public void AddDepartment(DepartmentView department)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("AddDepartment", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dep_name", department.Dep_name);
                    cmd.Parameters.AddWithValue("@Description", department.Description);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        public void DeleteDepartment(int DepId)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDepartment", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepId", DepId);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        public void EditDepartment(DepartmentView department,int DepId)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("EditDepartment", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepId", DepId);
                    cmd.Parameters.AddWithValue("@Dep_name", department.Dep_name);
                    cmd.Parameters.AddWithValue("@Description", department.Description);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        

        public Department GetDepartment(int DepId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetDepartments()
        {
            List<Department> ret = new List<Department>();
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllDepartments", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            ret =
                                (from row in dt.AsEnumerable()
                                 select new Department
                                 {
                                     DepId = row.Field<int>("DepId"),
                                     Dep_name = row.Field<string>("Dep_name"),
                                     Description = row.Field<string>("Descrption"),
                                     
                                 }
                                 ).ToList();

                        }
                    }
                }
            }
            return ret;
        }
    }
}
