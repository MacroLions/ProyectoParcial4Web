using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class DoctorData
    {
        public static bool Save(Doctor oDoctor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Doctor", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombredoctor", oDoctor.NombreDoctor);
                cmd.Parameters.AddWithValue("@especialidaddoctor", oDoctor.EspecialidadDoctor);

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
                SqlCommand cmd = new SqlCommand("Delete_Doctor", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@iddoctor", id);

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

        public static bool Edit(Doctor oDoctor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Doctor", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@iddoctor", oDoctor.IdDoctor);
                cmd.Parameters.AddWithValue("@nombredoctor", oDoctor.NombreDoctor);
                cmd.Parameters.AddWithValue("@especialidaddoctor", oDoctor.EspecialidadDoctor);

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

        public static Doctor Select(int id)
        {
            Doctor oDoctor = new Doctor();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Doctor", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@iddoctor", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oDoctor = new Doctor
                            {
                                IdDoctor = Convert.ToInt32(dr["idDoctor"]),
                                NombreDoctor = dr["nombreDoctor"].ToString(),
                                EspecialidadDoctor = dr["especialidadDoctor"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oDoctor;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Doctor> SelectAll()
        {
            Doctor oDoctor = new Doctor();
            List<Doctor> listaDoctor = new List<Doctor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Doctor", oConexion)
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
                            oDoctor = new Doctor
                            {
                                IdDoctor = Convert.ToInt32(dr["idDoctor"]),
                                NombreDoctor = dr["nombreDoctor"].ToString(),
                                EspecialidadDoctor = dr["especialidadDoctor"].ToString(),
                            };
                            listaDoctor.Add(oDoctor);
                        }
                    }
                    oConexion.Close();
                    return listaDoctor;
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
