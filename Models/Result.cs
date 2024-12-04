using System;

namespace DistrbuidoraAPI.Models;

public class Result<T>
{
    public string? Message { get; set; }
    public bool Complete { get; set; }
    public int Code { get; set; }
    public int Total { get; set; }
    public T Data { get; set; }

}
