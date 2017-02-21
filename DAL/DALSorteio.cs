using MySql.Data.MySqlClient;
using RodaARodaIvanaids.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                    conn.Open(); string query = "SELECT * FROM Sorteio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            DateTime data;
                            List<Usuario> us;
                            List<PremioSorteio> premios = new List<PremioSorteio>();
                            string nome, descricao;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                data = (DateTime)dr["data"];
                                us = DALUsuario.SelectFromSorteio(id);
                                premios = SelectPremios(id);
                                descricao = (string)dr["descricao"];
                                obj = new Sorteio(id, premios, data, nome, descricao, us);
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
        public static List<PremioSorteio> SelectPremios(int sid)
        {
            List<PremioSorteio> lista = new List<PremioSorteio>();
            PremioSorteio obj;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM PremioSorteio WHERE Sorteio_id = @Sorteio_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@Sorteio_id", MySqlDbType.Int32).Value = sid;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            Premio p = new Premio();
                            DateTime d;
                            Usuario u = new Usuario();
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                p = DALPremio.Select((Int32)dr["Premio_id"]);
                                d = (DateTime)dr["dataSorteio"];
                                u = DALUsuario.Select((Int32)dr["Usuario_id"]);
                                obj = new PremioSorteio(id, sid, p, d, u);
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
        public static Sorteio Select(int id)
        {
            Sorteio obj = new Sorteio();
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Sorteio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            DateTime data;
                            List<Usuario> us;
                            List<PremioSorteio> premios = new List<PremioSorteio>();
                            string nome, descricao;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                data = (DateTime)dr["data"]; 
                                us = DALUsuario.SelectFromSorteio(id);
                                premios = SelectPremios(id);
                                descricao = (string)dr["descricao"];
                                obj = new Sorteio(id, premios, data, nome, descricao, us);
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
            int id = 0;
            if (obj != new Sorteio())
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "INSERT INTO Sorteio (data, nome, descricao, sorteado) VALUES (@data, @nome, @descricao, @sorteado)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = obj.data;
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = obj.descricao;
                        cmd.Parameters.Add("@sorteado", MySqlDbType.Bit).Value = obj.sorteado;
                        cmd.ExecuteNonQuery();
                        foreach (var item in obj.premios)
                        {
                            DALPremioSorteio.Insert(item);                            
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Sorteio obj)
        {
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "DELETE FROM Sorteio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.id;
                    cmd.ExecuteNonQuery();
                    foreach (var item in obj.premios)
                    {
                        DALPremioSorteio.Delete(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Sorteio obj)
        {
            if (obj != new Sorteio())
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "UPDATE Sorteio SET data = @data, nome = @nome, descricao = @descricao, sorteado = @sorteado WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn); 
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.id;
                        cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = obj.data;
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = obj.descricao;
                        cmd.Parameters.Add("@sorteado", MySqlDbType.Bit).Value = obj.sorteado;
                        cmd.ExecuteNonQuery();
                        foreach (var item in obj.premios)
                        {
                            DALPremioSorteio.Update(item);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}