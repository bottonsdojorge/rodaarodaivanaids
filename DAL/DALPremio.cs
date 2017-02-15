using RodaARodaIvanaids.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.DAL
{
    public class DALPremio
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Premio> SelectAll()
        {
            List<Premio> premios = new List<Premio>();
            Premio premio;

            return premios;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Premio Select()
        {
            Premio premio = new Premio();
            return premio;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Premio obj)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Premio obj)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Premio obj)
        {

        }
    }
}