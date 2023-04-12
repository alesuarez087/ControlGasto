using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class PrecioBusiness
    {
        public readonly IPrecio Services;

        public PrecioBusiness(IPrecio service)
        {
            this.Services = service;
        }

        public Result GetHistorialPrecios(int id)
        {
            return this.Services.GetHistorialPrecios(id);
        }

        public Result Create(Precio precio)
        {
            return this.Services.Create(precio);
        }
    }
}
