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
        // Tem que verificar se o usuário é adminstrador para logar com login de administrador no servidor de banco de dados
        // Se não Ivanildo vai tirar nota.
        protected static string dbString = ConfigurationManager.ConnectionStrings["dbServer"].ConnectionString;
        protected static MySqlConnection conn;
    }
}