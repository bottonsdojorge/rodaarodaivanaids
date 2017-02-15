using RodaARodaIvanaids.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.DAL
{
    public class DALSorteio
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Sorteio> SelectAll()
        {
            List<Sorteio> sorteios = new List<Sorteio>();
            Sorteio sorteio;

            return sorteios;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Sorteio Select()
        {
            Sorteio sorteio = new Sorteio();
            return sorteio;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Sorteio obj)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Sorteio obj)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Sorteio obj)
        {

        }
    }
}