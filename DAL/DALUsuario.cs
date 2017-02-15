using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using RodaARodaIvanaids.Model;
namespace RodaARodaIvanaids.DAL
{
    public class DALUsuario
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Usuario> SelectAll()
        {

        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Usuario Select()
        {

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Usuario obj)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Usuario obj)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Usuario obj)
        {

        }
    }
}