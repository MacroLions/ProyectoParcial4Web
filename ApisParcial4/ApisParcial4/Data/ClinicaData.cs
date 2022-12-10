using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class ClinicaData
    {
        public static bool Save(Clinica oClinica)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Clinica", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombreClinica", oClinica.NombreClinica);
                cmd.Parameters.AddWithValue("@iddoctorasignado", oClinica.IdDoctorAsignado);

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
                SqlCommand cmd = new SqlCommand("Delete_Clinica", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idClinica", id);

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

        public static bool Edit(Clinica oClinica)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Clinica", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idClinica", oClinica.IdClinica);
                cmd.Parameters.AddWithValue("@nombreClinica", oClinica.NombreClinica);
                cmd.Parameters.AddWithValue("@iddoctorasignado", oClinica.IdDoctorAsignado);

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

        public static Clinica Select(int id)
        {
            Clinica oClinica = new Clinica();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Clinica", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idClinica", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oClinica = new Clinica
                            {
                                IdClinica = Convert.ToInt32(dr["idClinica"]),
                                NombreClinica = dr["nombreClinica"].ToString(),
                                IdDoctorAsignado = Convert.ToInt32(dr["idDoctorAsignado"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oClinica;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Clinica> SelectAll()
        {
            Clinica oClinica = new Clinica();
            List<Clinica> listaClinica = new List<Clinica>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Clinica", oConexion)
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
                            oClinica = new Clinica
                            {
                                IdClinica = Convert.ToInt32(dr["idClinica"]),
                                NombreClinica = dr["nombreClinica"].ToString(),
                                IdDoctorAsignado = Convert.ToInt32(dr["idDoctorAsignado"]),
                            };
                            listaClinica.Add(oClinica);
                        }
                    }
                    oConexion.Close();
                    return listaClinica;
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
