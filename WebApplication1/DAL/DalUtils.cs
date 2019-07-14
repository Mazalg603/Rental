using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DalUtils
    {
        public static string GetConnectionString()
        {
            return @"Data Source = (LocalDB)\MSSQLLocalDB;" +
          @"AttachDbFilename = |DataDirectory|\DatabaseProject.mdf;" +
             "Initial Catalog = DatabaseProject;" +
               "Integrated Security = True ;";
        }
    }
}