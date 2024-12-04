using System;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic;

public interface IProductoProveedorLogic
{
    public List<ProductoProveedor> GetProveedoresByProducto(string? clave, int? tipo);
    Task<int> SaveProductoProveedor(ProductoProveedor item);
    Task<bool> UpdateProductoProveedor(ProductoProveedorReq item);
    Task<bool> DeleteProductoProveedor(int id);
}
