using System;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic;

public class ProveedorLogic : IProveedorLogic
{
    private readonly IProveedorData Data;

    public ProveedorLogic(IProveedorData data)
    {
        Data = data;
    }


    public async Task<int> SaveProveedor(Proveedor item)
    {
        return await Data.SaveProveedor(item);
    }

    public List<Proveedor> GetProveedores()
    {
        return Data.GetProveedores();
    }

    public async Task<bool> UpdateProveedor(Proveedor item)
    {
        return await Data.UpdateProveedor(item);
    }

    public async Task<bool> DeleteProveedor(int id)
    {
        return await Data.DeleteProveedor(id);
    }
}
