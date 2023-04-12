using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class UnidadBusiness
    {
        public readonly IUnidad Services;

        public UnidadBusiness(IUnidad service)
        {
            this.Services = service;
        }

        public Result GetUnidades()
        {
            return this.Services.GetUnidad();
        }

        public Result Create(Unidad unidad)
        {
            return this.Services.Create(unidad);
        }
        public Result Update(Unidad unidad)
        {
            return this.Services.Update(unidad);
        }
        public Result Delete(int id)
        {
            return this.Services.Delete(id);
        }
    }
}
