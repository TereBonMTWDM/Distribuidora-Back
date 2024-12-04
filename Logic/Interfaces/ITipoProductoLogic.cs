using System;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic;

public interface ITipoProductoLogic
{
    public List<TipoProducto> GetTipos();
}
