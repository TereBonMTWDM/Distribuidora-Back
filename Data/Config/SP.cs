using System;

namespace DistrbuidoraAPI.Data;

public class SP
{
    public struct Producto
    {
        public const string Usp_Inv_Productos_Get = "Usp_Inv_Productos_Get";
        public const string Usp_Inv_Producto_Add = "Usp_Inv_Producto_Add";
        public const string Usp_Inv_Producto_Upd = "Usp_Inv_Producto_Upd";
        public const string Usp_Inv_Producto_Del = "Usp_Inv_Producto_Del";
    }

    public struct ProductoProveedor
    {
        
        public const string Usp_Inv_ProductoProveedor_Get = "Usp_Inv_ProductoProveedor_Get";
        
        public const string Usp_Inv_ProductoProveedor_Add = "Usp_Inv_ProductoProveedor_Add";
        // public const string Usp_Inv_ProductoProveedor_Save = "Usp_Inv_ProductoProveedor_Save";
        public const string Usp_Inv_ProductoProveedor_Upd = "Usp_Inv_ProductoProveedor_Upd";
        public const string Usp_Inv_ProductoProveedor_Del = "Usp_Inv_ProductoProveedor_Del";
    }

    public struct Proveedor
    {
        public const string Usp_Inv_Proveedor_Add = "Usp_Inv_Proveedor_Add";
        public const string Usp_Inv_Proveedor_Get = "Usp_Inv_Proveedor_Get";
        public const string Usp_Inv_Proveedor_Upd = "Usp_Inv_Proveedor_Upd";
        public const string Usp_Inv_Proveedor_Del = "Usp_Inv_Proveedor_Del";

    }

    public struct TipoProducto
    {
        public const string Usp_Inv_TipoProductos_Get = "Usp_Inv_TipoProductos_Get";
    }

}
