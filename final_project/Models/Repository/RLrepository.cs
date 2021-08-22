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
    public class RLrepository : IRLRepository
    {
        public void AddRL(RLView rl)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("AddRL", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RLType", rl.RLType);
                    cmd.Parameters.AddWithValue("@details", rl.details);
                    cmd.Parameters.AddWithValue("@DepId", rl.DepId);
                    cmd.Parameters.AddWithValue("@C_date", DateTime.Today);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }

        }

        public void DeleteRL(RLView rl)
        {
            
        }

        public void Edit(RLView rl)
        {
            
        }

        public IEnumerable<RL> GetRL()
        {
            List<RL> ret = new List<RL>();
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllRLs", cnn))
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
                                 select new RL
                                 {
                                     DepId = row.Field<int>("DepId"),
                                     RLType=row.Field<string>("RLType"),
                                     RLid = row.Field<int>("RLId"),
                                     details = row.Field<string>("details"),
                                     CreationDate = row.Field<DateTime>("C_date"),
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
