using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class MarcaBusiness
    {
        public readonly IMarca Services;

        public MarcaBusiness(IMarca service)
        {
            this.Services = service;
        }

        public Result GetMarcas()
        {
            return this.Services.GetMarcas();
        }

        public Result Create(Marca marca)
        {
            return this.Services.Create(marca);            
        }
        public Result Update(Marca marca)
        {
            return this.Services.Update(marca);
        }
        public Result Delete(int id)
        {
            return this.Services.Delete(id);
        }

    }
}
