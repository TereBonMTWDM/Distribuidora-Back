using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DistrbuidoraAPI.Data.DAO;

public class ProductoDAO
{
    private readonly DataContext _dataContext;
    private string connectionString = Environment.GetEnvironmentVariable("DATABASE"); //"Server=localhost,1433;Database=MAXIMOTI;User Id=SA;Password=T3r3Orozco;Encrypt=False;";
    public ProductoDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public List<Producto> GetProductos(string? clave, int? tipo)
    {
        List<Producto> lst = new List<Producto>();


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SP.Producto.Usp_Inv_Productos_Get, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@Tipo", tipo);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Clave = reader.GetString(reader.GetOrdinal("Clave")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                IdTipoProducto = reader.GetInt32(reader.GetOrdinal("IdTipoProducto")),
                                TipoProducto = reader.GetString(reader.GetOrdinal("TipoProducto")),
                                Precio = reader.GetDecimal(reader.GetOrdinal("Precio"))
                            };

                            lst.Add(producto);
                        }
                    }
                }
                Console.WriteLine("Productos obtenidos: " + lst.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return lst;
    }

    public async Task<int> SaveProducto(Producto item)
    {
        int id = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.Producto.Usp_Inv_Producto_Add, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Clave", item.Clave);
                    command.Parameters.AddWithValue("@Nombre", item.Nombre);
                    command.Parameters.AddWithValue("@Tipo", item.IdTipoProducto);
                    command.Parameters.AddWithValue("@Precio", item.Precio);
                    
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

    public async Task<bool> UpdateProducto(Producto item)
    {
        bool isSaved = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.Producto.Usp_Inv_Producto_Upd, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProducto", item.Id);
                    command.Parameters.AddWithValue("@Clave", item.Clave);
                    command.Parameters.AddWithValue("@Nombre", item.Nombre);
                    command.Parameters.AddWithValue("@Tipo", item.IdTipoProducto);
                    command.Parameters.AddWithValue("@Precio", item.Precio);
                    
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

    public async Task<bool> DeleteProducto(int id)
    {
        bool isSaved = false;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SP.Producto.Usp_Inv_Producto_Del, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProducto", id);
                    
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
