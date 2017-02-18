using MySql.Data.MySqlClient;
using RodaARodaIvanaids.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RodaARodaIvanaids.DAL
{
    public class DALPremioSorteio : DAL
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<PremioSorteio> SelectAll()
        {
            List<PremioSorteio> lista = new List<PremioSorteio>();
            PremioSorteio obj;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    string query = "SELECT * FROM PremioSorteio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                                obj = new PremioSorteio(id, p, d, u);
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
        public static PremioSorteio Select(int id)
        {
            PremioSorteio obj = new PremioSorteio() ;
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    string query = "SELECT * FROM PremioSorteio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    MySqlDataReader dr;
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            Premio p = new Premio();
                            DateTime d;
                            Usuario u = new Usuario();
                            while (dr.Read())
                            {
                                id = (Int32)dr["id"];
                                p = DALPremio.Select((Int32)dr["Premio_id"]);
                                d = (DateTime)dr["dataSorteio"];
                                u = DALUsuario.Select((Int32)dr["Usuario_id"]);
                                obj = new PremioSorteio(id, p, d, u);
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
        public static int Insert(PremioSorteio obj)
        {
            int id = 0;
            if (obj != new PremioSorteio())
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        string query = "INSERT INTO PremioSorteio (Premio_id, dataSorteio, Usuario_id) VALUES (@Premio_id, @dataSorteio, @Usuario) SET IDENTITY_SCOPE = @id;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add("@Premio_id", MySqlDbType.Int32).Value = obj.premio.id;
                        cmd.Parameters.Add("@Usuario_id", MySqlDbType.Int32).Value = obj.usuarioSorteado.id;
                        cmd.Parameters.Add("@dataSorteio", MySqlDbType.DateTime).Value = obj.dataSorteio;
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
        public static void Delete(PremioSorteio obj)
        {
            try
            {
                using (conn = new MySqlConnection(dbString))
                {
                    string query = "DELETE FROM PremioSorteio WHERE id = @id";
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
        public static void Update(PremioSorteio obj)
        {
            if (obj != new PremioSorteio() && obj != Select(obj.id))
            {
                try
                {
                    using (conn = new MySqlConnection(dbString))
                    {
                        string query = "UPDATE PremioSorteio SET Premio_id = @Premio_id, dataSorteio = @dataSorteio, Usuario_id = @Usuario_id WHERE id = @id;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.id;
                        cmd.Parameters.Add("@Premio_id", MySqlDbType.Int32).Value = obj.premio.id;
                        cmd.Parameters.Add("@Usuario_id", MySqlDbType.Int32).Value = obj.usuarioSorteado.id;
                        cmd.Parameters.Add("@dataSorteio", MySqlDbType.DateTime).Value = obj.dataSorteio;
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