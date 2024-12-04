using System;

namespace DistrbuidoraAPI.Models;

public class ProductoProveedorReq
{
    public int IdProducto { get; set; } 
    public int IdProveedor { get; set; }
    public string ClaveProveedor { get; set; } = string.Empty;
    public decimal Costo { get; set; }
    public string Notas { get; set; } = string.Empty;
}
