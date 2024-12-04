using System;
using DistrbuidoraAPI.Logic;
using DistrbuidoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistrbuidoraAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoLogic Logic;

    public ProductoController(IProductoLogic logic)
    {
        Logic = logic;
    }




    [HttpGet("GetProductos")]
    public Result<List<Producto>> GetProductos(string? clave, int? tipo)
    {
        Result<List<Producto>> result = new Result<List<Producto>>();

        try
        {
            result.Data = Logic.GetProductos(clave, tipo);

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


    [HttpPost]
    [Route("Save")]
    public async Task<Result<Producto>> Save(Producto item)
    {
        Result<Producto> result = new Result<Producto>();
        int id = 0;

        try
        {
            id = await Logic.SaveProducto(item);

            if(id == 0){
                result.Total = 0;
                result.Complete = false;
                result.Message = "Ocurrió un error al intentar guardar registro";
                result.Code = 500;

                return result;
            }

            item.Id = id;
            result.Data = item;
            result.Total = 1;
            result.Complete = true;
            result.Message = "Registro guardado";
            result.Code = 200;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Complete = false;
            result.Code = 500;

            throw;
        }
        return result;
    }

    [HttpPut]
    [Route("Update")]
    public async Task<Result<Producto>> Update(Producto item)
    {
        Result<Producto> result = new Result<Producto>();

        try
        {
            bool resp = await Logic.UpdateProducto(item);

            if (!resp)
            {
                result.Total = 0;
                result.Complete = false;
                result.Message = "Ocurrió un error al intentar actualizar registro";
                result.Code = 404;

                return result;
            }

            result.Data = item;
            result.Total = 1;
            result.Complete = true;
            result.Message = "Registro actualizado";
            result.Code = 200;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Complete = false;
            result.Code = 500;

            throw;
        }
        return result;
    }


    [HttpDelete]
    [Route("Delete")]
    public async Task<Result<Producto>> Delete(int id)
    {
        Result<Producto> result = new Result<Producto>();

        try
        {
            bool resp = await Logic.DeleteProducto(id);

            if (!resp)
            {
                result.Total = 0;
                result.Complete = false;
                result.Message = "Ocurrió un error al intentar eliminar el registro";
                result.Code = 404;

                return result;
            }

            result.Total = 1;
            result.Complete = true;
            result.Message = "Registro eliminado lógicamente";
            result.Code = 200;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.Complete = false;
            result.Code = 500;

            throw;
        }
        return result;
    }

}
