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
                            bool sorteado;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                data = (DateTime)dr["data"];
                                us = DALUsuario.SelectFromSorteio(id);
                                premios = SelectPremios(id);
                                descricao = (string)dr["descricao"];
                                sorteado = Convert.ToBoolean(dr["sorteado"]);
                                obj = new Sorteio(id, premios, data, nome, descricao, us, sorteado);
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
                                if (dr["Usuario_id"].ToString() != "")
                                {
                                    int uid = Convert.ToInt32(dr["Usuario_id"].ToString());
                                    u = DALUsuario.Select(uid);
                                }
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
                            bool sorteado;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                data = (DateTime)dr["data"]; 
                                us = DALUsuario.SelectFromSorteio(id);
                                premios = SelectPremios(id);
                                descricao = (string)dr["descricao"];
                                sorteado = Convert.ToBoolean(dr["sorteado"]);

                                obj = new Sorteio(id, premios, data, nome, descricao, us, sorteado);
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
        public static int Insert(Sorteio obj)
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
                        id = Convert.ToInt32(cmd.LastInsertedId);
                        foreach (var item in obj.premios)
                        {
                            item.idSorteio = id;
                            DALPremioSorteio.Insert(item);                            
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return id;
        }
        public static void InsertUsuario(Usuario obj, int sid)
        {
            if (obj != new Usuario())
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "INSERT INTO InscritoSorteio (Sorteio_id, Usuario_id) VALUES (@sid, @uid)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = sid;
                        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = obj.id;
                        cmd.ExecuteNonQuery();
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
                        cmd.Parameters.Add("@sorteado", MySqlDbType.Bit).Value = (obj.sorteado) ? 1 : 0;
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