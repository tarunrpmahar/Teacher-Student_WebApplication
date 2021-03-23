using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Application.Models
{
    public class Helper
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    }
}