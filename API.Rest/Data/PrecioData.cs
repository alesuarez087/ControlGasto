using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class PrecioData : IPrecio
    {
        private readonly AppDbContext Context;


        public PrecioData(AppDbContext context)
        {
            this.Context = context;
        }

        public Result GetHistorialPrecios(int id)
        {
            try
            {
                List<Precio> precios = this.Context.Precio.AsNoTracking().Where(p => p.IdProducto == id).OrderByDescending(p => p.Fecha).ToList();
                for (int i = 0; i < precios.Count - 1 ; i++)
                {
                    precios[i].Variabilidad = Math.Round((precios[i].Valor - precios[i + 1].Valor) * 100 / precios[i + 1].Valor, 2);
                }
                return new Result() { Data = precios };
            }
            catch(Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Create(Precio precio)
        {
            try
            {
                precio.Fecha = precio.Fecha.AddHours(-precio.Fecha.Hour);
                Context.Entry(precio).State = EntityState.Added;
                Context.SaveChanges();
                return new Result() { Success = "Precio modificado correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }
    }
}
