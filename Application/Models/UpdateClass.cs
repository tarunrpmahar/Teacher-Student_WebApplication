using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Application.Models
{
    public class UpdateClass
    {
        public static List<ResourceClass> GetResourceList
        {
            get
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
        //public void ModifyList(ResourceClass resourceClass, HttpPostedFileBase file)
        //{
        //    using (SqlConnection con = new SqlConnection(Helper.connectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand("spUpdateRes", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@re_id", resourceClass.ResId);
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            string filename = Path.GetFileName(file.FileName);
        //            string imgpath = Path.Combine(Server.MapPath("~/Cover_page/"), filename);
        //            file.SaveAs(imgpath);
        //        }
        //        cmd.Parameters.AddWithValue("@images", "~/User_Images/" + file.FileName);
        //        cmd.Parameters.AddWithValue("@title", resourceClass.Title);
        //        cmd.Parameters.AddWithValue("@author", resourceClass.Author);
        //        cmd.Parameters.AddWithValue("@subjects", resourceClass.Subject);
        //        cmd.Parameters.AddWithValue("@years", resourceClass.Years);
        //        cmd.Parameters.AddWithValue("@descriptions", resourceClass.Files);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //}
    }
}