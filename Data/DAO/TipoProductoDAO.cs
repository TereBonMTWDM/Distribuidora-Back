using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DistrbuidoraAPI.Data.DAO;

public class TipoProductoDAO
{
    private readonly DataContext _dataContext;
    private string connectionString = Environment.GetEnvironmentVariable("DATABASE");
    public TipoProductoDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<TipoProducto> GetTipos()
    {
        List<TipoProducto> lst = new List<TipoProducto>();


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SP.TipoProducto.Usp_Inv_TipoProductos_Get, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoProducto item = new TipoProducto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                            };

                            lst.Add(item);
                        }
                    }
                }
                Console.WriteLine("Tipos obtenidos: " + lst.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return lst;
    }

}
