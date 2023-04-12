using API.Rest.Business;
using API.Rest.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public readonly MarcaBusiness Business;

        public MarcaController(IMarca service)
        {
            this.Business = new MarcaBusiness(service);
        }

        [HttpGet]
        public ActionResult<Result> Get()
        {
            return this.Business.GetMarcas();
        }

        [HttpPost]
        public ActionResult<Result> Post(Marca marca)
        {
            return this.Business.Create(marca);
        }

        [HttpPut]
        public ActionResult<Result> Put(Marca marca)
        {
            return this.Business.Update(marca);
        }

        [HttpDelete("{id}")]
        public ActionResult<Result> Delete(int id)
        {
            return this.Business.Delete(id);
        }
    }
}
