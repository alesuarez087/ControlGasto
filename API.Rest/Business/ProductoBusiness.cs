using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class ProductoBusiness
    {
        public readonly IProducto Services;

        public ProductoBusiness(IProducto service)
        {
            this.Services = service;
        }

        public Result GetProductos()
        {
            return this.Services.GetProductos();            
        }
        public Result GetProductos(DateTime fecha)
        {
            return this.Services.GetProductos(fecha);
        }

        public Result GetProductos(DateTime fecha, int idLocal)
        {
            return this.Services.GetProductos(fecha, idLocal);
        }

        //public Result GetProducto(int id)
        //{
        //    return this.Services.GetProducto(id, DateTime.Today);
        //}

        public Result Create(Producto producto)
        {
            return this.Services.Create(producto);
        }
        public Result Update(Producto producto)
        {
            return this.Services.Update(producto);
        }
        public Result Delete(int id)
        {
            return this.Services.Delete(id);
        }
    }
}
