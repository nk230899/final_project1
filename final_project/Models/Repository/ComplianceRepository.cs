using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.Repository
{
    public class ComplianceRepository : IComplianceRepository
    {
        public void AddComment(string comm, int EId, int RLId)
        {
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("AddComment", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EId", EId);
                    cmd.Parameters.AddWithValue("@RLId", RLId);
                    cmd.Parameters.AddWithValue("@comment", comm);
                    cmd.Parameters.AddWithValue("@C_date", DateTime.Today);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }

        public IEnumerable<Comments> MyComments(int EId,int RLId)
        {
            List<Comments> ret = new List<Comments>();
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllComments", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EId", EId);
                    cmd.Parameters.AddWithValue("@RLId", RLId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            ret =
                                (from row in dt.AsEnumerable()
                                 select new Comments
                                 {
                                     RLId = row.Field<int>("RLId"),
                                     comment = row.Field<string>("Comment"),
                                     CreationDate=row.Field<DateTime>("C_date")

                                 }
                                 ).ToList();

                        }
                    }
                }
            }
            return ret;
        }

        public IEnumerable<RL> MyRLs(int EId)
        {
            List<RL> ret = new List<RL>();
            using (SqlConnection cnn = new SqlConnection("data source=(local);database=final_project; integrated security=SSPI"))
            {
                using (SqlCommand cmd = new SqlCommand("GetMyRLs", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EId", EId);
                    //cmd.Parameters.AddWithValue("@RLId", RLId);
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
                                     RLType = row.Field<string>("RLType"),
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
