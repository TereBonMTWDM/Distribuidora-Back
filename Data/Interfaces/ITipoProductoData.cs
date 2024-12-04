using System;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Data;

public interface ITipoProductoData
{
    public List<TipoProducto> GetTipos();
}
