using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using System.Data;
using final_project.Models.ViewModels;

namespace final_project.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepsoitory
    {
        
        public void AddEmployee(EmployeeView employee)
        {
            using(SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("AddEmployee", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fname", employee.First_name);
                    cmd.Parameters.AddWithValue("@lname", employee.First_name);
                    cmd.Parameters.AddWithValue("@dob", employee.dob);
                    cmd.Parameters.AddWithValue("@email", employee.email);
                    cmd.Parameters.AddWithValue("@p_number", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DepId", employee.DepId);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        public void DeleteEmployee(int EId)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteEmployee", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EId", EId);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        public void EditEmployee(EmployeeView employee,int id)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("EditEmployee", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("EId", id);
                    cmd.Parameters.AddWithValue("@fname", employee.First_name);
                    cmd.Parameters.AddWithValue("@lname", employee.Last_name);
                    cmd.Parameters.AddWithValue("@dob", employee.dob);
                    cmd.Parameters.AddWithValue("@email", employee.email);
                    cmd.Parameters.AddWithValue("@p_number", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DepId", employee.DepId);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        

        public IEnumerable<Employee> GetEmployees()

        {

            List<Employee> ret = new List<Employee>();
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployee", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using ( SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            ret =
                                (from row in dt.AsEnumerable()
                                 select new Employee
                                 {
                                     Eid = row.Field<int>("EId"),
                                     First_name=row.Field<string>("f_name"),
                                     Last_name=row.Field<string>("l_name"),
                                     dob=row.Field<DateTime>("dob"),
                                     email=row.Field<string>("email"),
                                     PhoneNumber=row.Field<string>("p_number"),
                                     DepId=row.Field<int>("DepId")
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
