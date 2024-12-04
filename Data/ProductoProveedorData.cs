using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data.DAO;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Data;

public class ProductoProveedorData : IProductoProveedorData
{
    private readonly DataContext DataContext;
    private readonly ProductoProveedorDAO Dao;

    public ProductoProveedorData(DataContext dataContext)
    {
        DataContext = dataContext;
        Dao = new ProductoProveedorDAO(dataContext);
    }


    public List<ProductoProveedor> GetProveedoresByProducto(string? clave, int? tipo)
    {
        return Dao.GetProveedoresByProducto(clave,  tipo);
    }



    public async Task<int> SaveProductoProveedor(ProductoProveedor item)
    {
        return await Dao.SaveProductoProveedor(item);
    }

    public async Task<bool> UpdateProductoProveedor(ProductoProveedorReq item)
    {
        return await Dao.UpdateProductoProveedor(item);
    }

    public async Task<bool> DeleteProductoProveedor(int id)
    {
        return await Dao.DeleteProductoProveedor(id);
    }

}
