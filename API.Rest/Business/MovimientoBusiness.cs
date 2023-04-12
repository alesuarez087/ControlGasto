using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class MovimientoBusiness
    {
        public readonly IMovimiento services;

        public MovimientoBusiness(IMovimiento service)
        {
            this.services = service;
        }
        public Result GetMovimientos()
        {
            return services.GetMovimientos();
        }

        public Result GetMovimiento(int id)
        {
            return services.GetMovimiento(id);
        }

        public Result Create(Movimiento movimiento)
        {
            return services.Create(movimiento);
        }
        public Result Update(Movimiento movimiento)
        {
            return services.Update(movimiento);
        }
    }
}
