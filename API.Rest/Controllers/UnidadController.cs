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
    public class UnidadController : ControllerBase
    {
        public readonly UnidadBusiness Business;

        public UnidadController(IUnidad service)
        {
            this.Business = new UnidadBusiness(service);
        }


        [HttpGet]
        public ActionResult<Result> Get()
        {
            return this.Business.GetUnidades();
        }

        [HttpPost]
        public ActionResult<Result> Post(Unidad unidad)
        {
            return this.Business.Create(unidad);
        }

        [HttpPut]
        public ActionResult<Result> Put(Unidad unidad)
        {
            return this.Business.Update(unidad);
        }

        [HttpDelete("{id}")]
        public ActionResult<Result> Delete(int id)
        {
            return this.Business.Delete(id);
        }
    }
}
