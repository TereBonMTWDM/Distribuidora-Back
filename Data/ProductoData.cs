using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data.DAO;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Data;

public class ProductoData : IProductoData
{
    private readonly DataContext DataContext;
    private readonly ProductoDAO Dao;

    public ProductoData(DataContext dataContext)
    {
        DataContext = dataContext;
        Dao = new ProductoDAO(dataContext);
    }

    public List<Producto> GetProductos(string? clave, int? tipo)
    {
        return Dao.GetProductos(clave,  tipo);
    }

    public async Task<int> SaveProducto(Producto item)
    {
        return await Dao.SaveProducto(item);
    }

    public async Task<bool> UpdateProducto(Producto item)
    {
        return await Dao.UpdateProducto(item);
    }

    public async Task<bool> DeleteProducto(int id)
    {
        return await Dao.DeleteProducto(id);
    }
}
