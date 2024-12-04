using System;
using DistrbuidoraAPI.Data.Config;
using DistrbuidoraAPI.Data.DAO;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Data;

public class ProveedorData : IProveedorData
{
    private readonly DataContext DataContext;
    private readonly ProveedorDAO Dao;

    public ProveedorData(DataContext dataContext)
    {
        DataContext = dataContext;
        Dao = new ProveedorDAO(dataContext);
    }

    public async Task<int> SaveProveedor(Proveedor item)
    {
        return await Dao.SaveProveedor(item);
    }

    public List<Proveedor> GetProveedores()
    {
        return Dao.GetProveedores();
    }

    public async Task<bool> UpdateProveedor(Proveedor item)
    {
        return await Dao.UpdateProveedor(item);
    }

    public async Task<bool> DeleteProveedor(int id)
    {
        return await Dao.DeleteProveedor(id);
    }



}
