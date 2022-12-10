using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class DiagnosticoData
    {
        public static bool Save(Diagnostico oDiagnostico)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Diagnostico", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombreDiagnostico", oDiagnostico.NombreDiagnostico);
                cmd.Parameters.AddWithValue("@idPaciente", oDiagnostico.IdPaciente);

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
                SqlCommand cmd = new SqlCommand("Delete_Diagnostico", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idDiagnostico", id);

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

        public static bool Edit(Diagnostico oDiagnostico)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Diagnostico", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idDiagnostico", oDiagnostico.IdDiagnostico);
                cmd.Parameters.AddWithValue("@nombreDiagnostico", oDiagnostico.NombreDiagnostico);
                cmd.Parameters.AddWithValue("@idPaciente", oDiagnostico.IdPaciente);

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

        public static Diagnostico Select(int id)
        {
            Diagnostico oDiagnostico = new Diagnostico();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Diagnostico", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idDiagnostico", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oDiagnostico = new Diagnostico
                            {
                                IdDiagnostico = Convert.ToInt32(dr["idDiagnostico"]),
                                NombreDiagnostico = dr["nombreDiagnostico"].ToString(),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oDiagnostico;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Diagnostico> SelectAll()
        {
            Diagnostico oDiagnostico = new Diagnostico();
            List<Diagnostico> listaDiagnostico = new List<Diagnostico>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Diagnostico", oConexion)
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
                            oDiagnostico = new Diagnostico
                            {
                                IdDiagnostico = Convert.ToInt32(dr["idDiagnostico"]),
                                NombreDiagnostico = dr["nombreDiagnostico"].ToString(),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                            };
                            listaDiagnostico.Add(oDiagnostico);
                        }
                    }
                    oConexion.Close();
                    return listaDiagnostico;
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
