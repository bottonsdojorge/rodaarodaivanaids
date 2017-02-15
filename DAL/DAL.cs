using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.DAL
{
    public class DAL
    {
        protected static string databaseString = ConfigurationManager.ConnectionStrings["dbServer"].ConnectionString;
        protected static MySqlConnection conn;
    }
}