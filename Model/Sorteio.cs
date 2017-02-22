using RodaARodaIvanaids.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.Model
{
    public class Sorteio
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private List<PremioSorteio> _premios;
        public List<PremioSorteio> premios
        {
            get { return _premios; }
            set { _premios = value; }
        }
        private List<Usuario> _inscritos;
        public List<Usuario> inscritos
        {
            get { return _inscritos; }
            set { _inscritos = value; }
        }
        
        private DateTime _data;
        public DateTime data
        {
            get { return _data; }
            set { _data = value; }
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
        private bool _sorteado;
        public bool sorteado
        {
            get { return _sorteado; }
            set { _sorteado = value; }
        }
        
        public Sorteio()
        {
            id = 0;
            premios = new List<PremioSorteio>();
            inscritos = new List<Usuario>();
            data = new DateTime();
            nome = "";
            descricao = "";
            sorteado = false;
        }
        public Sorteio(int i, List<PremioSorteio> p, DateTime d, string n, string desc, List<Usuario> u, bool sorteado = false)
        {
            id = i;
            premios = p;
            inscritos = u;
            data = d;
            nome = n;
            descricao = desc;
            sorteado = false;
        }
        public void AdicionarPremio(Premio p)
        {
            if (p != new Premio())
            {
                PremioSorteio ps = new PremioSorteio();
                ps.premio = p;
                ps.dataSorteio = data;
                ps.idSorteio = id;
                premios.Add(ps);
                DALPremioSorteio.Insert(ps);
            }
            else
            {
                throw new ArgumentNullException("Prêmio nulo");
            }
        }
        public void InscreverUsuario(Usuario u)
        {
            // Fazendo gambiarra pq preguiça
            if (u != new Usuario())
            {
                inscritos.Add(u);
            }
            else
                throw new ArgumentException("Usuário inválido");
        }
        // Parametros: id do Sorteio ou o próprio sorteio.
        public void Sortear()
        {
            // Deveria ir pro DAL mas n vai não
            if (sorteado == false)
            {
                List<Usuario> us = DALUsuario.SelectFromSorteio(id);
                Usuario u;
                int c = us.Count;
                Random r = new Random();
                int i;
                foreach (var premio in premios)
                {
                    i = r.Next(c);
                    u = us[i];
                    premio.usuarioSorteado = u;
                }
                sorteado = true;
                DALSorteio.Update(this);
            }
            else
                throw new InvalidOperationException("Sorteio já realizado");
            /*
             * 0 - Verifica se o sorteio já não foi sorteado.
             * 1 - Pega a quantidade de usuários normais cadastrados no banco;
             * 2 - Mete um random com o número de cadastrados para cada prêmio do sorteio;
             * 3 - Verifica se o registro não é Admin
             * 3.1 - Se for admin, volte para 2.
             * 3.2 - Se não for admin, instância os objetos (premio, usuario, etc...) e registra no banco.
             */

        }
    }
}