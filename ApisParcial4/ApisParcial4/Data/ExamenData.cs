using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class ExamenData
    {
        public static bool Save(Examen oExamen)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Examen", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombreExamen", oExamen.NombreExamen);
                cmd.Parameters.AddWithValue("@idPaciente", oExamen.IdPaciente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Delete_Examen", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idExamen", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public static bool Edit(Examen oExamen)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Examen", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idExamen", oExamen.IdExamen);
                cmd.Parameters.AddWithValue("@nombreExamen", oExamen.NombreExamen);
                cmd.Parameters.AddWithValue("@idPaciente", oExamen.IdPaciente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public static Examen Select(int id)
        {
            Examen oExamen = new Examen();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Examen", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idExamen", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oExamen = new Examen
                            {
                                IdExamen = Convert.ToInt32(dr["idExamen"]),
                                NombreExamen = dr["nombreExamen"].ToString(),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oExamen;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Examen> SelectAll()
        {
            Examen oExamen = new Examen();
            List<Examen> listaExamen = new List<Examen>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Examen", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oExamen = new Examen
                            {
                                IdExamen = Convert.ToInt32(dr["idExamen"]),
                                NombreExamen = dr["nombreExamen"].ToString(),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                            };
                            listaExamen.Add(oExamen);
                        }
                    }
                    oConexion.Close();
                    return listaExamen;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}
