using System;
using DistrbuidoraAPI.Models;
using DistrbuidoraAPI.Data;

namespace DistrbuidoraAPI.Logic
{

    public class ProductoLogic : IProductoLogic
    {
        private readonly IProductoData Data;

        public ProductoLogic(IProductoData data)
        {
            Data = data;
        }

        public List<Producto> GetProductos(string? clave, int? tipo)
        {
            return Data.GetProductos(clave, tipo);
        }

        public async Task<int> SaveProducto(Producto item)
        {
            return await Data.SaveProducto(item);
        }

        public async Task<bool> UpdateProducto(Producto item)
        {
            return await Data.UpdateProducto(item);
        }

        public async Task<bool> DeleteProducto(int id)
        {
            return await Data.DeleteProducto(id);
        }
    }
}