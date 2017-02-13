using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.Model
{
    public class Premio
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _nome;
        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public Premio()
        {
            id = 0;
            nome = "";
            descricao = "";
        }
        public Premio(int i, string n, string d)
        {
            id = i;
            nome = n;
            descricao = d;
        }
    }
}