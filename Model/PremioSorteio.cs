using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.Model
{
    public class PremioSorteio
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Premio _premio;
        public Premio premio
        {
            get { return _premio; }
            set { _premio = value; }
        }
        private DateTime _dataSorteio;
        public DateTime dataSorteio
        {
            get { return _dataSorteio; }
            set { _dataSorteio = value; }
        }
        private Usuario _usuarioSorteado;
        public Usuario usuarioSorteado
        {
            get { return _usuarioSorteado; }
            set { _usuarioSorteado = value; }
        }
        public PremioSorteio()
        {
            id = 0;
            premio = new Premio();
            dataSorteio = new DateTime();
            usuarioSorteado = new Usuario();
        }
        public PremioSorteio(int i, Premio p, DateTime d, Usuario u)
        {
            id = i;
            premio = p;
            dataSorteio = d;
            usuarioSorteado = u;
        }
    }
}