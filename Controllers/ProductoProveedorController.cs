using System;
using DistrbuidoraAPI.Logic;
using DistrbuidoraAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace DistrbuidoraAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoProveedorController : ControllerBase
{
    private readonly IProductoProveedorLogic Logic;

    public ProductoProveedorController(IProductoProveedorLogic logic)
    {
        Logic = logic;
    }

    [HttpGet("Get")]
    public Result<List<ProductoProveedor>> GetProveedoresByProducto(string? clave, int? tipo)
    {
        Result<List<ProductoProveedor>> result = new Result<List<ProductoProveedor>>();

        try
        {
            result.Data = Logic.GetProveedoresByProducto(clave, tipo);

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
    public async Task<Result<ProductoProveedor>> Save(ProductoProveedor item)
    {
        Result<ProductoProveedor> result = new Result<ProductoProveedor>();
        int id = 0;

        try
        {
            id = await Logic.SaveProductoProveedor(item);

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
    public async Task<Result<ProductoProveedorReq>> Update(ProductoProveedorReq item)
    {
        Result<ProductoProveedorReq> result = new Result<ProductoProveedorReq>();

        try
        {
            bool resp = await Logic.UpdateProductoProveedor(item);

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
    [Route("Delete/{id}")]
    public async Task<Result<ProductoProveedor>> Delete(int id)
    {
        Result<ProductoProveedor> result = new Result<ProductoProveedor>();

        try
        {
            bool resp = await Logic.DeleteProductoProveedor(id);

            if (!resp)
            {
                result.Total = 0;
                result.Complete = false;
                result.Message = "Ocurrió un error al intentar eliminar registro";
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
