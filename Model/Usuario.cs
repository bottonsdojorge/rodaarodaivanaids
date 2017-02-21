using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.Model
{
    public class Usuario
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
        private string _matricula;
        public string matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        private string _cpf;
        public string cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        private bool _admin;
        public bool admin
        {
            get { return _admin; }
            set { _admin = value; }
        }
        
        public Usuario()
        {
            id = 0;
            nome = "";
            matricula = "";
            cpf = "";
            admin = false;
        }
        public Usuario(int id, string n, string m, string c, bool admin = false)
        {
            this.id = id;
            nome = n;
            matricula = m;
            cpf = validarCPF(c);
            this.admin = admin;
        }
        private string validarCPF(string c)
        {
            if (true)
            {
                return c;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void inserirCPF(string c)
        {
            cpf = validarCPF(c);
        }
    }
}