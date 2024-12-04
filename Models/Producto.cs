using System;

namespace DistrbuidoraAPI.Models;

public class Producto
{
    public int Id { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int IdTipoProducto { get; set; }
    public string? TipoProducto { get; set; }
    public decimal Precio { get; set; }
}
