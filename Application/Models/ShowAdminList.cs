using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Application.Models
{
    public class ShowAdminList
    {
        public List<AdminClass> GetTempAdminList()
        {
            List<AdminClass> List = new List<AdminClass>();
            using (SqlConnection con = new SqlConnection(Helper.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetNewAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    List.Add(new AdminClass
                    {
                        Id = Convert.ToInt16(dr["Adminid"].ToString()),
                        Fname = dr["fname"].ToString(),
                        Lname = dr["lname"].ToString(),
                        Age = Convert.ToInt32(dr["age"].ToString()),
                        Gender=dr["gender"].ToString(),
                        Contact=Convert.ToInt64(dr["contact"].ToString()),
                        Username = dr["Adminusername"].ToString(),
                        Password = dr["Adminpassword"].ToString()
                    });
                }
                return List;
            }
        }
    }
}