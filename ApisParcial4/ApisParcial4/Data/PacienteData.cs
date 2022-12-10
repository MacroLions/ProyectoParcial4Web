using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class PacienteData
    {
        public static bool Save(Paciente oPaciente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Paciente", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombrePaciente", oPaciente.NombrePaciente);
                cmd.Parameters.AddWithValue("@apellidoPaciente", oPaciente.ApellidoPaciente);
                cmd.Parameters.AddWithValue("@correo", oPaciente.Correo);
                cmd.Parameters.AddWithValue("@pass", Encriptar.GetSHA256(oPaciente.Pass));

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
                SqlCommand cmd = new SqlCommand("Delete_Paciente", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idPaciente", id);

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

        public static bool Edit(Paciente oPaciente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Paciente", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idPaciente", oPaciente.IdPaciente);
                cmd.Parameters.AddWithValue("@nombrePaciente", oPaciente.NombrePaciente);
                cmd.Parameters.AddWithValue("@apellidoPaciente", oPaciente.ApellidoPaciente);
                cmd.Parameters.AddWithValue("@correo", oPaciente.Correo);
                cmd.Parameters.AddWithValue("@usuario", oPaciente.Usuario);
                cmd.Parameters.AddWithValue("@pass", Encriptar.GetSHA256(oPaciente.Pass));

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

        public static Paciente Select(int id)
        {
            Paciente oPaciente = new Paciente();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Paciente", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idPaciente", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oPaciente = new Paciente
                            {
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                                NombrePaciente = dr["nombrePaciente"].ToString(),
                                ApellidoPaciente = dr["apellidoPaciente"].ToString(),
                                Correo = dr["correo"].ToString(),
                                Usuario = dr["usuario"].ToString(),
                                Pass = dr["pass"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return oPaciente;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Paciente> SelectAll()
        {
            Paciente oPaciente = new Paciente();
            List<Paciente> listaPaciente = new List<Paciente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Paciente", oConexion)
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
                            oPaciente = new Paciente
                            {
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                                NombrePaciente = dr["nombrePaciente"].ToString(),
                                ApellidoPaciente = dr["apellidoPaciente"].ToString(),
                                Correo = dr["correo"].ToString(),
                                Usuario = dr["usuario"].ToString(),
                                Pass = dr["pass"].ToString(),
                            };
                            listaPaciente.Add(oPaciente);
                        }
                    }
                    oConexion.Close();
                    return listaPaciente;
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
