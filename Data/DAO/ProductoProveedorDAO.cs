using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DistrbuidoraAPI.Data.DAO;

public class ProductoProveedorDAO
{
    private readonly DataContext _dataContext;
    private string connectionString = Environment.GetEnvironmentVariable("DATABASE");
    public ProductoProveedorDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<ProductoProveedor> GetProveedoresByProducto(string? clave, int? tipo)
    {
        List<ProductoProveedor> lst = new List<ProductoProveedor>();


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SP.ProductoProveedor.Usp_Inv_ProductoProveedor_Get, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@Tipo", tipo);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Productos y Proveedores con Total de Productos Comprados:");
                        Console.WriteLine("-------------------------------------------------");

                        while (reader.Read())
                        {
                            ProductoProveedor proveedores = new ProductoProveedor
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                IdProducto = reader.GetInt32(reader.GetOrdinal("IdProducto")),
                                ClaveProducto = reader.GetString(reader.GetOrdinal("ClaveProducto")),
                                NombreProducto = reader.GetString(reader.GetOrdinal("NombreProducto")),
                                IdTipoProducto = reader.GetInt32(reader.GetOrdinal("IdTipoProducto")),
                                // TipoProducto = reader.GetString(reader.GetOrdinal("TipoProducto")),
                                Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),

                                IdProveedor = reader.GetInt32(reader.GetOrdinal("IdProveedor")),
                                NombreProveedor = reader.GetString(reader.GetOrdinal("NombreProveedor")),
                                ClaveProveedor = reader.GetString(reader.GetOrdinal("ClaveProveedor")),
                                Costo = reader.GetDecimal(reader.GetOrdinal("Costo")),
                                Notas = reader.GetString(reader.GetOrdinal("Notas"))
                            };

                            lst.Add(proveedores);
                        }
                    }
                }
                Console.WriteLine("Registros obtenidos: " + lst.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return lst;
    }


    public async Task<int> SaveProductoProveedor(ProductoProveedor item)
    {
        int idNew = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.ProductoProveedor.Usp_Inv_ProductoProveedor_Add, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    
                    command.Parameters.AddWithValue("@IdProveedor", item.IdProveedor);
                    command.Parameters.AddWithValue("@Clave", item.ClaveProveedor);
                    command.Parameters.AddWithValue("@Costo", item.Costo);
                    command.Parameters.AddWithValue("@Notas", item.Notas);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idNew = (int)reader.GetInt32(reader.GetOrdinal("Id"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return idNew;
    }

    public async Task<bool> UpdateProductoProveedor(ProductoProveedorReq item)
    {
        bool isSaved = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.ProductoProveedor.Usp_Inv_ProductoProveedor_Upd, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    command.Parameters.AddWithValue("@IdProveedor", item.IdProveedor);
                    command.Parameters.AddWithValue("@Clave", item.ClaveProveedor);
                    command.Parameters.AddWithValue("@Costo", item.Costo);
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

    public async Task<bool> DeleteProductoProveedor(int id)
    {
        bool isSaved = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.ProductoProveedor.Usp_Inv_ProductoProveedor_Del, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProductoProveedor", id);
                    
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
