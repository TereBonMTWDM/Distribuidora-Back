using System;

namespace DistrbuidoraAPI.Models;

public class Proveedor
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Notas { get; set; }
    public int? TotalCompras { get; set; }
}
