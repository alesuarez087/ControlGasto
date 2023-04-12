using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class UnidadData : IUnidad
    {
        private readonly AppDbContext Context;


        public UnidadData(AppDbContext context)
        {
            this.Context = context;
        }

        public Result Create(Unidad unidad)
        {
            try
            {
                Context.Entry(unidad).State = EntityState.Added;
                Context.SaveChanges();
                return new Result() { Success = "Unidad agregada correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Delete(int id)
        {
            try
            {
                var tipo = new Unidad() { Id = id };

                Context.Remove(tipo);
                Context.SaveChanges();
                return new Result() { Success = "Unidad eliminada correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result GetUnidad()
        {
            try
            {
                return new Result() { Data = Context.Unidad.OrderBy(u=> u.Nombre).ToList() };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Update(Unidad unidad)
        {
            try
            {
                Context.Entry(unidad).State = EntityState.Modified;
                Context.SaveChanges();
                return new Result() { Success = "Unidad modificada correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message};
            }
        }
    }
}
