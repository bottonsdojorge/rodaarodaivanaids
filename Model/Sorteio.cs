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
            data = new DateTime();
            nome = "";
            descricao = "";
            sorteado = false;
        }
        public Sorteio(int i, List<PremioSorteio> p, DateTime d, string n, string desc)
        {
            id = i;
            premios = p;
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
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        // Mover isso para o DAL Sorteio
        // Parametros: id do Sorteio ou o próprio sorteio.
        public void Sortear()
        {
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