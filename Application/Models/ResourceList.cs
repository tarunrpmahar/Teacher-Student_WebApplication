using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Application.Models
{
    public class ResourceList
    {
        public List<ResourceClass> GetResourceList()
        {
            List<ResourceClass> List = new List<ResourceClass>();
            using (SqlConnection con = new SqlConnection(Helper.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetResource", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    List.Add(new ResourceClass
                    {
                        ResId = Convert.ToInt16(dr["re_id"].ToString()),
                        Images = dr["images"].ToString(),
                        Title = dr["title"].ToString(),
                        Author = dr["author"].ToString(),
                        Subject = dr["subjects"].ToString(),
                        Years = Convert.ToInt16(dr["years"].ToString()),
                        Files = dr["descriptions"].ToString(),
                    });
                }
                return List;
            }
        }
    }
}