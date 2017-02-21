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
    public class DALPremio : DAL
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Premio> SelectAll()
        {
            List<Premio> lista = new List<Premio>();
            Premio obj;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Premio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            string nome, descricao;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                descricao = (string)dr["descricao"];
                                obj = new Premio(id, nome, descricao);
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
        public static Premio Select(int id)
        {
            Premio obj = new Premio();
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Premio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            string nome, descricao;
                            while (dr.Read())
                            {
                                nome = (string)dr["nome"];
                                descricao = (string)dr["descricao"];
                                obj = new Premio(id, nome, descricao);
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
        public static void Insert(Premio obj)
        {
            int id = 0;
            if (obj != new Premio())
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "INSERT INTO Premio (nome, descricao) VALUES (@nome, @descricao)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = obj.descricao;
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
        public static void Delete(Premio obj)
        {
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "DELETE FROM Premio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Premio obj)
        {
            if (obj != new Premio() && obj != Select(obj.id))
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "UPDATE Premio SET nome = @nome, descricao = @descricao WHERE id = @id;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.id;
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = obj.descricao;
                        cmd.ExecuteNonQuery();
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