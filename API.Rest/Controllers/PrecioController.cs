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
    public class PrecioController : ControllerBase
    {
        public readonly PrecioBusiness Business;

        public PrecioController(IPrecio service)
        {
            this.Business = new PrecioBusiness(service);
        }


        [HttpGet("{id}")]
        public ActionResult<Result> Get(int id)
        {
            return this.Business.GetHistorialPrecios(id);
        }

        [HttpPost]
        public ActionResult<Result> Post(Precio precio)
        {
            return this.Business.Create(precio);
        }
    }
}
