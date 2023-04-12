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
    public class MovimientoController : ControllerBase
    {
        public readonly MovimientoBusiness business;


        public MovimientoController(IMovimiento service)
        {
            this.business = new MovimientoBusiness(service);
        }

        // GET: api/<MovimientoController>
        [HttpGet]
        public Result Get()
        {
            return this.business.GetMovimientos();
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            return this.business.GetMovimiento(id);
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public Result Post(Movimiento movimiento)
        {
            return this.business.Create(movimiento);
        }

        // PUT api/<MovimientoController>/5
        [HttpPut]
        public Result Put(Movimiento movimiento)
        {
            return this.business.Update(movimiento);
        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
