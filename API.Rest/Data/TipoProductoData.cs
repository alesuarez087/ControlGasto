using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class TipoProductoData : ITipoProducto
    {
        private readonly AppDbContext Context;


        public TipoProductoData(AppDbContext context)
        {
            this.Context = context;
        }

        public Result Create(TipoProducto tipo)
        {
            try
            {
                Context.Entry(tipo).State = EntityState.Added;
                Context.SaveChanges();
                return new Result() { Success = "Tipo de producto agregado correctamente" };
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
                var tipo = new TipoProducto() { Id = id };

                Context.Remove(tipo);
                Context.SaveChanges();
                return new Result() { Success = "Tipo de producto eliminado correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result GetTiposProducto()
        {
            try
            {
                return new Result() { Data = Context.TipoProducto.OrderBy(t=>t.Nombre).ToList() };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Update(TipoProducto tipo)
        {
            try
            {
                Context.Entry(tipo).State = EntityState.Modified;
                Context.SaveChanges();
                return new Result() { Success = "Tipo de producto modificado correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }
    }
}
