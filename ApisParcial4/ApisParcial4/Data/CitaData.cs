using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class CitaData
    {
        public static bool Save(Cita oCita)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Cita", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idpaciente", oCita.IdPaciente);
                cmd.Parameters.AddWithValue("@idclinica", oCita.IdClinica);
                cmd.Parameters.AddWithValue("@fechacita", oCita.FechaCita);
                cmd.Parameters.AddWithValue("@horacita", oCita.HoraCita);

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
                SqlCommand cmd = new SqlCommand("Delete_Cita", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idCita", id);

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

        public static bool Edit(Cita oCita)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Cita", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idcita", oCita.IdCita);
                cmd.Parameters.AddWithValue("@idpaciente", oCita.IdPaciente);
                cmd.Parameters.AddWithValue("@idclinica", oCita.IdClinica);
                cmd.Parameters.AddWithValue("@fechacita", oCita.FechaCita);
                cmd.Parameters.AddWithValue("@Horacita", oCita.FechaCita);

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

        public static Cita Select(int id)
        {
            Cita oCita = new Cita();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Cita", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idCita", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCita = new Cita
                            {
                                IdCita = Convert.ToInt32(dr["idCita"]),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                                IdClinica = Convert.ToInt32(dr["idClinica"]),
                                FechaCita = dr["fechaCita"].ToString(),
                                HoraCita= dr["horaCita"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oCita;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Cita> SelectAll()
        {
            Cita oCita = new Cita();
            List<Cita> listaCita = new List<Cita>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Cita", oConexion)
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
                            oCita = new Cita
                            {
                                IdCita = Convert.ToInt32(dr["idCita"]),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                                IdClinica = Convert.ToInt32(dr["idClinica"]),
                                FechaCita = dr["fechaCita"].ToString(),
                                HoraCita = dr["horaCita"].ToString(),

                            };
                            listaCita.Add(oCita);
                        }
                    }
                    oConexion.Close();
                    return listaCita;
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
