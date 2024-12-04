using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DistrbuidoraAPI.Data.DAO;

public class ProveedorDAO
{
    private readonly DataContext _dataContext;
    private string connectionString = Environment.GetEnvironmentVariable("DATABASE");
    public ProveedorDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> SaveProveedor(Proveedor item)
    {
        int id = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.Proveedor.Usp_Inv_Proveedor_Add, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", item.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                    command.Parameters.AddWithValue("@Notas", item.Notas);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = (int)reader.GetInt32(reader.GetOrdinal("Id"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return id;
    }

    public List<Proveedor> GetProveedores()
    {
        List<Proveedor> lst = new List<Proveedor>();


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SP.Proveedor.Usp_Inv_Proveedor_Get, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Proveedores con Total de Productos Comprados:");
                        Console.WriteLine("-------------------------------------------------");

                        while (reader.Read())
                        {
                            Proveedor item = new Proveedor
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Notas = reader.GetString(reader.GetOrdinal("Notas")),
                                TotalCompras = reader.GetInt32(reader.GetOrdinal("TotalCompras"))
                            };

                            lst.Add(item);
                        }
                    }
                }
                Console.WriteLine("Proveedores obtenidos: " + lst.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return lst;
    }

    public async Task<bool> UpdateProveedor(Proveedor item)
    {
        bool isSaved = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.Proveedor.Usp_Inv_Proveedor_Upd, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProveedor", item.Id);
                    command.Parameters.AddWithValue("@Nombre", item.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                    command.Parameters.AddWithValue("@Notas", item.Notas);
                    
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    isSaved = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return isSaved;
    }

    public async Task<bool> DeleteProveedor(int id)
    {
        bool isSaved = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.Proveedor.Usp_Inv_Proveedor_Del, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProveedor", id);
                    
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    isSaved = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return isSaved;
    }


}
