using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using RodaARodaIvanaids.Model;
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
                    string query = "SELECT * FROM Usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int id;
                            string nome, matricula, cpf;
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                nome = (string)dr["nome"];
                                matricula = (string)dr["matricula"];
                                cpf = (string)dr["cpf"];
                                obj = new Usuario(id, nome, matricula, cpf);
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
                    string query = "SELECT * FROM Usuario WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            string nome, matricula, cpf;
                            while (dr.Read())
                            {
                                nome = (string)dr["nome"];
                                matricula = (string)dr["matricula"];
                                cpf = (string)dr["cpf"];
                                obj = new Usuario(id, nome, matricula, cpf);
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
        public static int Insert(Usuario obj)
        {
            int id = 0;
            if (obj != new Usuario())
            { 
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        string query = "INSERT INTO Usuario (nome, matricula, cpf) VALUES (@nome, @matricula, @cpf) SET IDENTITY_SCOPE = @id;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = obj.nome;
                        cmd.Parameters.Add("@matricula", MySqlDbType.VarChar).Value = obj.matricula;
                        cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = obj.cpf;
                        cmd.ExecuteNonQuery();
                        id = (Int32)cmd.Parameters["@id"].Value;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return id;
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void Delete(Usuario obj)
        {
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    string query = "DELETE FROM Usuario WHERE id = @id";
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
                        string query = "UPDATE Usuario SET nome = @nome, matricula = @matricula, cpf = @cpf WHERE id = @id;";
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
    }
}