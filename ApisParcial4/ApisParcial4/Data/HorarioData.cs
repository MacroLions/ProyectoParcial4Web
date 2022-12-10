using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class HorarioData
    {
        public static bool Save(Horario oHorario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Horario", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@horarioapertura", oHorario.HorarioApertura);
                cmd.Parameters.AddWithValue("@horariocierre", oHorario.HorarioCierre);
                cmd.Parameters.AddWithValue("@idclinicaasignada", oHorario.IdClinicaAsignada);

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
                SqlCommand cmd = new SqlCommand("Delete_Horario", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idHorario", id);

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

        public static bool Edit(Horario oHorario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Horario", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idHorario", oHorario.IdHorario);
                cmd.Parameters.AddWithValue("@horarioapertura", oHorario.HorarioApertura);
                cmd.Parameters.AddWithValue("@horariocierre", oHorario.HorarioCierre);
                cmd.Parameters.AddWithValue("@idclinicaasignada", oHorario.IdClinicaAsignada);

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

        public static Horario Select(int id)
        {
            Horario oHorario = new Horario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Horario", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idHorario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oHorario = new Horario
                            {
                                IdHorario = Convert.ToInt32(dr["idHorario"]),
                                HorarioApertura = dr["horarioApertura"].ToString(),
                                HorarioCierre = dr["horarioCierre"].ToString(),
                                IdClinicaAsignada = Convert.ToInt32(dr["idHorario"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oHorario;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Horario> SelectAll()
        {
            Horario oHorario = new Horario();
            List<Horario> listaHorario = new List<Horario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Horario", oConexion)
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
                            oHorario = new Horario
                            {
                                IdHorario = Convert.ToInt32(dr["idHorario"]),
                                HorarioApertura = dr["horarioApertura"].ToString(),
                                HorarioCierre = dr["horarioCierre"].ToString(),
                                IdClinicaAsignada = Convert.ToInt32(dr["idHorario"]),
                            };
                            listaHorario.Add(oHorario);
                        }
                    }
                    oConexion.Close();
                    return listaHorario;
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
