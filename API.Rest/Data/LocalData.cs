using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class LocalData : ILocal
    {
        private readonly AppDbContext Context;


        public LocalData(AppDbContext context)
        {
            this.Context = context;
        }

        public Result GetLocal()
        {
            try
            {
                return new Result() { Data = Context.Local.OrderBy(x => x.Nombre).ToList() };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

    }
}
