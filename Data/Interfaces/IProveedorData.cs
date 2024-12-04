using System;
using DistrbuidoraAPI.Models;

namespace DistrbuidoraAPI.Data;

public interface IProveedorData
{
    Task<int> SaveProveedor(Proveedor item);
    public List<Proveedor> GetProveedores();
    Task<bool> UpdateProveedor(Proveedor item);
    Task<bool> DeleteProveedor(int id);

}
