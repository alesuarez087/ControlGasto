using API.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Business
{
    public class LocalBusiness
    {
        public readonly ILocal Services;

        public LocalBusiness(ILocal service)
        {
            this.Services = service;
        }

        public Result GetLocal()
        {
            return this.Services.GetLocal();
        }

    }
}
