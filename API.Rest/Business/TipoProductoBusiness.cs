using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class TipoProductoBusiness
    {
        public readonly ITipoProducto Services;

        public TipoProductoBusiness(ITipoProducto service)
        {
            this.Services = service;
        }

        public Result GetTiposProducto()
        {
            return this.Services.GetTiposProducto();
        }

        public Result Create(TipoProducto tipo)
        {
            return this.Services.Create(tipo);            
        }
        public Result Update(TipoProducto tipo)
        {
            return this.Services.Update(tipo);
        }
        public Result Delete(int id)
        {
            return this.Services.Delete(id);
        }
    }
}
