using API.Rest.Business;
using API.Rest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly ProductoBusiness Business;

        public ProductoController(IProducto service)
        {
            this.Business = new ProductoBusiness(service);
        }


        [HttpGet]
        public ActionResult<Result> Get()
        {
            return this.Business.GetProductos();
        }

        [HttpGet("{fecha}/{idLocal}")]
        public ActionResult<Result> Get(DateTime fecha, int idLocal)
        {
            return this.Business.GetProductos(fecha, idLocal);
        }

        [HttpGet("{fecha}")]
        public ActionResult<Result> GetProductos(DateTime fecha)
        {
            return this.Business.GetProductos(fecha);
        }

        //[HttpGet("{id}")]
        //public ActionResult<Result> Get(int id)
        //{
        //    return this.Business.GetProducto(id);
        //}

        [HttpPost]
        public ActionResult<Result> Post(Producto producto)
        {
            return this.Business.Create(producto);
        }

        [HttpPut]
        public ActionResult<Result> Put(Producto producto)
        {
            return this.Business.Update(producto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Result> Delete(int id)
        {
            return this.Business.Delete(id);
        }
    }
}
