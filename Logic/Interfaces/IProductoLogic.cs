using System;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic
{

    public interface IProductoLogic
    {
        public List<Producto> GetProductos(string? clave, int? tipo);
        Task<int> SaveProducto(Producto item);
        Task<bool> UpdateProducto(Producto item);
        Task<bool> DeleteProducto(int id);

    }

}