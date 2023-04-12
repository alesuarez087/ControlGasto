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
    public class TipoProductoController : ControllerBase
    {
        public readonly TipoProductoBusiness Business;

        public TipoProductoController(ITipoProducto service)
        {
            this.Business = new TipoProductoBusiness(service);
        }


        [HttpGet]
        public ActionResult<Result> Get()
        {
            return this.Business.GetTiposProducto();
        }

        [HttpPost]
        public ActionResult<Result> Post(TipoProducto tipo)
        {
            return this.Business.Create(tipo);
        }

        [HttpPut]
        public ActionResult<Result> Put(TipoProducto tipo)
        {
            return this.Business.Update(tipo);
        }

        [HttpDelete("{id}")]
        public ActionResult<Result> Delete(int id)
        {
            return this.Business.Delete(id);
        }
    }
}
