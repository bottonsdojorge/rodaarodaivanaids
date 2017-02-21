using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using RodaARodaIvanaids.Model;
using System.Data;
namespace RodaARodaIvanaids.DAL
{
    public class DALUsuario : DAL
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Usuario> SelectAll()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario obj;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            bool admin;
                            string nome, matricula, cpf;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                matricula = (string)dr["matricula"];
                                cpf = (string)dr["cpf"];
                                admin = (bool)dr["admin"];
                                obj = new Usuario(id, nome, matricula, cpf, admin);
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
        }[DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Usuario> SelectAllNonAdmin()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario obj;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Usuario WHERE admin = false";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            bool admin;
                            string nome, matricula, cpf;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                matricula = (string)dr["matricula"];
                                cpf = (string)dr["cpf"];
                                admin = (bool)dr["admin"];
                                obj = new Usuario(id, nome, matricula, cpf, admin);
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
        public static Usuario Select(int id)
        {
            Usuario obj = new Usuario();
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Usuario WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            bool admin;
                            string nome, matricula, cpf;
                            while (dr.Read())
                            {
                                nome = (string)dr["nome"];
                                matricula = (string)dr["matricula"];
                                cpf = (string)dr["cpf"];
                                admin = (bool)dr["admin"];
                                obj = new Usuario(id, nome, matricula, cpf, admin);
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
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Usuario> SelectFromSorteio(int sid)
        {
            List<Usuario> u = new List<Usuario>();
            Usuario obj = new Usuario();
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "SELECT * FROM Usuario u INNER JOIN InscritoSorteio i ON i.Usuario_id = u.id WHERE i.Sorteio_id = @sid";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = sid;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            bool admin;
                            string nome, matricula, cpf;
                            while (dr.Read())
                            {
                                int id = (int)dr["id"];
                                nome = (string)dr["nome"];
                                matricula = (string)dr["matricula"];
                                cpf = (string)dr["cpf"];
                                admin = (bool)dr["admin"];
                                obj = new Usuario(id, nome, matricula, cpf, admin);
                                u.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return u;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Usuario obj)
        {
            int id = 0;
            if (obj != new Usuario())
            { 
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "INSERT INTO Usuario (nome, matricula, cpf, admin) VALUES (@nome, @matricula, @cpf, @admin)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@matricula", MySqlDbType.VarChar).Value = obj.matricula;
                        cmd.Parameters.Add("@admin", MySqlDbType.Bit).Value = obj.admin;
                        cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = obj.cpf;
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
        public static void Delete(Usuario obj)
        {
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    conn.Open(); string query = "DELETE FROM Usuario WHERE id = @id";
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
        public static void Update(Usuario obj)
        {
            if (obj != new Usuario() && obj != Select(obj.id))
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        conn.Open(); string query = "UPDATE Usuario SET nome = @nome, matricula = @matricula, cpf = @cpf WHERE id = @id;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.id;
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@matricula", MySqlDbType.VarChar).Value = obj.matricula;
                        cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = obj.cpf;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void Login(string cpf, string matricula)
        {
            MySqlConnection conn = new MySqlConnection(dbString);
            try
            {
                conn.Open(); string query = "SELECT * FROM Usuario WHERE matricula = @matricula AND cpf = @cpf";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cpf;
                cmd.Parameters.Add("@matricula", MySqlDbType.VarChar).Value = matricula;
                MySqlDataReader dr;
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        HttpContext.Current.Session["autenticado"] = true;
                        HttpContext.Current.Session["admin"] = Convert.ToBoolean(dr["admin"]);                        
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            AcessoPublico();
        }

        public static void LogOff()
        {
            HttpContext.Current.Session["autenticado"] = false;
            HttpContext.Current.Session["admin"] = false;
            AcessoPrivado();
        }

        public static void AcessoPrivado()
        {
            if (HttpContext.Current.Session["autenticado"] == null || (bool)HttpContext.Current.Session["autenticado"] == false)
            {
                HttpContext.Current.Response.Redirect("~/publico/index.aspx");
            }
        }
        public static void AcessoAdmin()
        {
            if (HttpContext.Current.Session["autenticado"] == null || (bool)HttpContext.Current.Session["autenticado"] == false || (bool)HttpContext.Current.Session["admin"] == false || HttpContext.Current.Session["admin"] == null)
            {
                HttpContext.Current.Response.Redirect("~/publico/index.aspx");
            }
        }

        public static void AcessoPublico()
        {
            if (HttpContext.Current.Session["autenticado"] != null && (bool)HttpContext.Current.Session["autenticado"] == true)
            {
                HttpContext.Current.Response.Redirect("~/publico/index.aspx");
            }
        }
    }
}