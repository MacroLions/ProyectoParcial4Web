using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApisParcial4.Data
{
    public class MedicamentoData
    {
        public static bool Save(Medicamento oMedicamento)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Medicamento", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nombreMedicamento", oMedicamento.NombreMedicamento);
                cmd.Parameters.AddWithValue("@idPaciente", oMedicamento.IdPaciente);

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
                SqlCommand cmd = new SqlCommand("Delete_Medicamento", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idMedicamento", id);

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

        public static bool Edit(Medicamento oMedicamento)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Medicamento", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idMedicamento", oMedicamento.IdMedicamento);
                cmd.Parameters.AddWithValue("@nombreMedicamento", oMedicamento.NombreMedicamento);
                cmd.Parameters.AddWithValue("@idPaciente", oMedicamento.IdPaciente);

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

        public static Medicamento Select(int id)
        {
            Medicamento oMedicamento = new Medicamento();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Medicamento", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idMedicamento", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oMedicamento = new Medicamento
                            {
                                IdMedicamento = Convert.ToInt32(dr["idMedicamento"]),
                                NombreMedicamento = dr["nombreMedicamento"].ToString(),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return oMedicamento;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static List<Medicamento> SelectAll()
        {
            Medicamento oMedicamento = new Medicamento();
            List<Medicamento> listaMedicamento = new List<Medicamento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Medicamento", oConexion)
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
                            oMedicamento = new Medicamento
                            {
                                IdMedicamento = Convert.ToInt32(dr["idMedicamento"]),
                                NombreMedicamento = dr["nombreMedicamento"].ToString(),
                                IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                            };
                            listaMedicamento.Add(oMedicamento);
                        }
                    }
                    oConexion.Close();
                    return listaMedicamento;
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
