using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class MarcaData : IMarca
    {
        private readonly AppDbContext Context;


        public MarcaData(AppDbContext context)
        {
            this.Context = context;
        }



        public Result Create(Marca marca)
        {
            try
            {
                Context.Entry(marca).State = EntityState.Added;
                Context.SaveChanges();
                return new Result()
                {
                    Success = "Marca agregada correctamente"
                };
            }
            catch(Exception ex)
            {
                return new Result()
                {
                    Error = ex.Message
                };
            }
        }

        public Result Delete(int id)
        {
            try
            {
                
                var marca = new Marca() { Id = id };
                Context.Remove(marca);
                Context.SaveChanges();

                return new Result() { Success = "Marca eliminada correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result GetMarcas()
        {
            try
            {
                return new Result() { Data = Context.Marca.OrderBy(x=>x.Nombre).ToList() };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Update(Marca marca)
        {
            try
            {
                Context.Entry(marca).State = EntityState.Modified;
                Context.SaveChanges();
                return new Result() { Success = "Marca modificada correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }
    }
}
