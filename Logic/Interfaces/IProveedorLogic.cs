using System;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Logic;

public interface IProveedorLogic
{
    Task<int> SaveProveedor(Proveedor item);
    public List<Proveedor> GetProveedores();
    Task<bool> UpdateProveedor(Proveedor item);
    Task<bool> DeleteProveedor(int id);
}
