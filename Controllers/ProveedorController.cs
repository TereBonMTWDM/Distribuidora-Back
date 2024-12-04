using System;
using DistrbuidoraAPI.Logic;
using DistrbuidoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistrbuidoraAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProveedorController : ControllerBase
{
    private readonly IProveedorLogic Logic;

    public ProveedorController(IProveedorLogic logic)
    {
        Logic = logic;
    }


    [HttpPost]
    [Route("Save")]
    public async Task<Result<Proveedor>> Save(Proveedor item)
    {
        Result<Proveedor> result = new Result<Proveedor>();
        int id = 0;

        try
        {
            id = await Logic.SaveProveedor(item);

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


    [HttpGet("GetProveedores")]
    public Result<List<Proveedor>> GetProveedores()
    {
        Result<List<Proveedor>> result = new Result<List<Proveedor>>();

        try
        {
            result.Data = Logic.GetProveedores();

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

    [HttpPut]
    [Route("Update")]
    public async Task<Result<Proveedor>> Update(Proveedor item)
    {
        Result<Proveedor> result = new Result<Proveedor>();

        try
        {
            bool resp = await Logic.UpdateProveedor(item);

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
    public async Task<Result<Proveedor>> Delete(int id)
    {
        Result<Proveedor> result = new Result<Proveedor>();

        try
        {
            bool resp = await Logic.DeleteProveedor(id);

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
