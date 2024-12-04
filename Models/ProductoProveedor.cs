using System;

namespace DistrbuidoraAPI.Models;

public class ProductoProveedor
{
    public int Id { get; set; }
    public int IdProducto { get; set; } 
    public string? ClaveProducto { get; set; }
    public string? NombreProducto { get; set; }
    public int IdTipoProducto { get; set; }
    public decimal Precio { get; set; }
    
    public int IdProveedor { get; set; }
    public string? NombreProveedor { get; set; }
    public string ClaveProveedor { get; set; } = string.Empty;
    public decimal Costo { get; set; }
    public string Notas { get; set; } = string.Empty;
}
