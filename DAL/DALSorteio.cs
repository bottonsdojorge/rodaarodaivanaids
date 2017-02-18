using MySql.Data.MySqlClient;
using RodaARodaIvanaids.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.DAL
{
    public class DALSorteio : DAL
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Sorteio> SelectAll()
        {
            List<Sorteio> lista = new List<Sorteio>();
            Sorteio obj;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    string query = "SELECT * FROM Sorteio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            DateTime data;
                            Usuario usuario;
                            List<PremioSorteio> premios = new List<PremioSorteio>();
                            string nome, descricao;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                data = (DateTime)dr["data"];
                                usuario = DALUsuario.Select((Int32)dr["Usuario_id"]);
                                // Código para selecionar todos os premiosSorteio aqui...
                                descricao = (string)dr["descricao"];
                                obj = new Sorteio(id, premios, data, nome, descricao);
                                lista.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Sorteio Select()
        {
            Sorteio obj = new Sorteio();
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    string query = "SELECT * FROM Sorteio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            DateTime data;
                            Usuario usuario;
                            List<PremioSorteio> premios = new List<PremioSorteio>();
                            string nome, descricao;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                data = (DateTime)dr["data"];
                                usuario = DALUsuario.Select((Int32)dr["Usuario_id"]);
                                // Código para selecionar todos os premiosSorteio aqui...
                                descricao = (string)dr["descricao"];
                                obj = new Sorteio(id, premios, data, nome, descricao);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
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