using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data.DAO;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Data;

public class TipoProductoData : ITipoProductoData
{
    private readonly DataContext DataContext;
    private readonly TipoProductoDAO Dao;

    public TipoProductoData(DataContext dataContext)
    {
        DataContext = dataContext;
        Dao = new TipoProductoDAO(dataContext);
    }

    public List<TipoProducto> GetTipos()
    {
        return Dao.GetTipos();
    }

}
