using System;

namespace DistrbuidoraAPI.Models;

public class ProductoResp
{
    public int Id { get; set; }
    public string ClaveProducto { get; set; } = string.Empty;
    public string NombreProducto { get; set; } = string.Empty;
    public int IdTipoProducto { get; set; }
    public string TipoProducto { get; set; } = string.Empty;
    public decimal PrecioProducto { get; set; }
    public string NombreProveedor { get; set; } = string.Empty;
    public string ClaveProveedor { get; set; } = string.Empty;
    public decimal CostoProveedor { get; set; }
}
