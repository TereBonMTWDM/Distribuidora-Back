using System;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic;

public class TipoProductoLogic : ITipoProductoLogic
{
    private readonly ITipoProductoData Data;

    public TipoProductoLogic(ITipoProductoData data)
    {
        Data = data;
    }

    public List<TipoProducto> GetTipos()
    {
        return Data.GetTipos();
    }
}
