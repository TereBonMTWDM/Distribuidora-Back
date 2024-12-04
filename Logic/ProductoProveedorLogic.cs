using System;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Logic;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic;

public class ProductoProveedorLogic : IProductoProveedorLogic
{
    private readonly IProductoProveedorData Data;

    public ProductoProveedorLogic(IProductoProveedorData data)
    {
        Data = data;
    }

    public List<ProductoProveedor> GetProveedoresByProducto(string? clave, int? tipo)
    {
        return Data.GetProveedoresByProducto(clave,  tipo);
    }


    public async Task<int> SaveProductoProveedor(ProductoProveedor item)
    {
        return await Data.SaveProductoProveedor(item);
    }

    public async Task<bool> UpdateProductoProveedor(ProductoProveedorReq item)
    {
        return await Data.UpdateProductoProveedor(item);
    }

    public async Task<bool> DeleteProductoProveedor(int id)
    {
        return await Data.DeleteProductoProveedor(id);
    }
}
