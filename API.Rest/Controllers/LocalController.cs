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
    public class LocalController : ControllerBase
    {
        public readonly LocalBusiness Business;

        public LocalController(ILocal service)
        {
            this.Business = new LocalBusiness(service);
        }

        [HttpGet]
        public ActionResult<Result> Get()
        {
            return this.Business.GetLocal();
        }

        //[HttpPost]
        //public ActionResult<Result> Post(Marca marca)
        //{
        //    return this.Business.Create(marca);
        //}

        //[HttpPut]
        //public ActionResult<Result> Put(Marca marca)
        //{
        //    return this.Business.Update(marca);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<Result> Delete(int id)
        //{
        //    return this.Business.Delete(id);
        //}
    }
}
