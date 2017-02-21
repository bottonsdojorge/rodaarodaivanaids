using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.Model
{
    public class InscritoSorteio
    {
        private Usuario _usuario;
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private Sorteio myVar;

        public Sorteio MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
                
    }
}