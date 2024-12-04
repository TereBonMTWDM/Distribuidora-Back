using System;
using DistrbuidoraAPI.Logic;
using DistrbuidoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistrbuidoraAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TipoProductoController : ControllerBase
{
    private readonly ITipoProductoLogic Logic;

    public TipoProductoController(ITipoProductoLogic logic)
    {
        Logic = logic;
    }

    [HttpGet("GetTipos")]
    public Result<List<TipoProducto>> GetTipos()
    {
        Result<List<TipoProducto>> result = new Result<List<TipoProducto>>();

        try
        {
            result.Data = Logic.GetTipos();

            if (result.Data.Count == 0)
            {
                result.Total = 0;
                result.Complete = true;
                result.Message = "No hay registros";
                result.Code = 404;
            }
            else
            {
                result.Total = result.Data.Count;
                result.Complete = true;
                result.Message = "Success";
                result.Code = 200;
            }
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Complete = false;
            result.Code = 500;
        }
        return result;
    }


}
