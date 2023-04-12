using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class ProductoData : IProducto
    {
        private readonly AppDbContext Context;


        public ProductoData(AppDbContext context)
        {
            this.Context = context;
        }

        public Result Create(Producto producto)
        {
            try
            {
                Context.Entry(producto).State = EntityState.Added;
                producto.Precio.IdProducto = Context.SaveChanges();
                //producto.Precio.Fecha = DateTime.Today;
                Context.Entry(producto.Precio).State = EntityState.Added;
                Context.SaveChanges();
                return new Result() { Success = "Producto agregado correctamente" };
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
                var producto = new Producto() { Id = id };

                Context.Remove(producto);
                Context.SaveChanges();
                return new Result() { Success = "Producto eliminado correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result GetProductos()
        {
            try
            {
                
                var precios = from p in Context.Precio
                              join mf in (
                                from p in Context.Precio
                                group p by new { p.IdProducto } into g
                                select new { IdProducto = g.Key.IdProducto, Fecha = g.Max(p => p.Fecha) }
                              ) on new { p.IdProducto, p.Fecha } equals new { IdProducto = mf.IdProducto, mf.Fecha }
                              select new { IdProducto=p.IdProducto, Fecha=p.Fecha, Valor=p.Valor };

                return new Result()
                {
                    Data = from p in Context.Producto
                           join tipoProducto in Context.TipoProducto on p.IdTipoProducto equals tipoProducto.Id
                           join unidad in Context.Unidad on p.IdUnidad equals unidad.Id
                           join marca in Context.Marca on p.IdMarca equals marca.Id
                           join precio in precios on p.Id equals Convert.ToInt32(precio.IdProducto)
                           orderby p.Nombre
                           select new { p.Id, p.Nombre, p.IdMarca, p.IdTipoProducto, p.IdUnidad, tipoProducto, unidad, marca, precio }
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    Error = ex.Message
                };
            }
        }

        public Result GetProductos(DateTime fecha)
        {
            fecha.AddHours(4);

            try
            {
                var precios = from p in Context.Precio
                              join mf in (
                                from p in Context.Precio
                                where p.Fecha <= fecha
                                group p by new { p.IdProducto } into g
                                select new { IdProducto = g.Key.IdProducto, Fecha = g.Max(p => p.Fecha) }
                              ) on new { p.IdProducto, p.Fecha } equals new { IdProducto = mf.IdProducto, mf.Fecha }
                              select new { IdProducto = p.IdProducto, Fecha = p.Fecha, Valor = p.Valor };              

                return new Result()
                {
                    Data = from p in Context.Producto
                           join tipoProducto in Context.TipoProducto on p.IdTipoProducto equals tipoProducto.Id
                           join unidad in Context.Unidad on p.IdUnidad equals unidad.Id
                           join marca in Context.Marca on p.IdMarca equals marca.Id
                           join precio in precios on p.Id equals Convert.ToInt32(precio.IdProducto)
                           orderby p.Nombre
                           select new { p.Id, p.Nombre, p.IdMarca, p.IdTipoProducto, p.IdUnidad, tipoProducto, unidad, marca, precio }
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    Error = ex.Message
                };
            }
        }

        public Result GetProductos(DateTime fecha, int idLocal)
        {
            fecha = fecha.AddHours(5);
            try
            {
                var precios = from p in Context.Precio
                              join mf in (
                                from p in Context.Precio
                                join l in Context.Local on p.IdLocal equals l.IdLocal
                                where p.Fecha <= fecha && l.IdLocal == idLocal
                                group p by new { p.IdProducto } into g
                                select new { IdProducto = g.Key.IdProducto, Fecha = g.Max(p => p.Fecha) }
                              ) on new { p.IdProducto, p.Fecha } equals new { IdProducto = mf.IdProducto, mf.Fecha }
                              select new { IdProducto = p.IdProducto, Fecha = p.Fecha, Valor = p.Valor };

                return new Result()
                {
                    Data = from p in Context.Producto
                           join tipoProducto in Context.TipoProducto on p.IdTipoProducto equals tipoProducto.Id
                           join unidad in Context.Unidad on p.IdUnidad equals unidad.Id
                           join marca in Context.Marca on p.IdMarca equals marca.Id
                           join precio in precios on p.Id equals Convert.ToInt32(precio.IdProducto)
                           orderby p.Nombre
                           select new { p.Id, p.Nombre, p.IdMarca, p.IdTipoProducto, p.IdUnidad, tipoProducto, unidad, marca, precio }
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    Error = ex.Message
                };
            }
        }

        public Producto GetProducto(int id, DateTime fecha, int? idLocal)
        {
            try
            {

                var precios = from p in Context.Precio
                              join mf in (
                                from pr in Context.Precio
                                where (pr.Fecha <= fecha && pr.IdLocal == idLocal)
                                group pr by new { pr.IdProducto } into g
                                select new { IdProducto = g.Key.IdProducto, Fecha = g.Max(p => p.Fecha) }
                              ) on new { p.IdProducto, p.Fecha } equals new { IdProducto = mf.IdProducto, mf.Fecha }
                              select new { IdProducto = p.IdProducto, Fecha = p.Fecha, Valor = p.Valor, IdLocal = p.IdLocal };

                if (precios.Count() < 1) return null; // new Result() { Error = "Error al recuperar los precios de algún producto" };

                var producto = from po in Context.Producto
                               join tipoProducto in Context.TipoProducto on po.IdTipoProducto equals tipoProducto.Id
                               join unidad in Context.Unidad on po.IdUnidad equals unidad.Id
                               join marca in Context.Marca on po.IdMarca equals marca.Id
                               join precio in precios on po.Id equals Convert.ToInt32(precio.IdProducto)
                               join local in Context.Local on precio.IdLocal equals local.IdLocal
                               where po.Id == id
                               orderby po.Nombre
                               select new { po.Id, po.Nombre, po.IdMarca, po.IdTipoProducto, po.IdUnidad, tipoProducto, unidad, marca, precio, local };

                Producto prod = new Producto();

                foreach(var i in producto)
                {
                    prod.Id = i.Id;
                    prod.IdMarca = i.IdMarca;
                    prod.IdTipoProducto = i.IdTipoProducto;
                    prod.IdUnidad = i.IdUnidad;
                    prod.Marca = i.marca;
                    prod.Nombre = i.Nombre;
                    prod.TipoProducto = i.tipoProducto;
                    prod.Unidad = i.unidad;

                    prod.Precio = new Precio();
                    prod.Precio.Valor = i.precio.Valor;
                    prod.Precio.IdProducto = i.precio.IdProducto;
                    prod.Precio.Fecha = Convert.ToDateTime(i.precio.Fecha);
                    
                    prod.Precio.Local = new Local();
                    prod.Precio.Local.Nombre = i.local.Nombre;
                    prod.Precio.Local.IdLocal = i.local.IdLocal;
                }

                return prod;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result Update(Producto producto)
        {
            try
            {
                Context.Entry(producto).State = EntityState.Modified;

                var precios = from p in Context.Precio
                              where p.IdProducto == producto.Id
                              group p by new
                              { p.IdProducto, p.Valor } into g
                              select new { g.Key.IdProducto, g.Key.Valor, Fecha = (DateTime?)g.Max(p => p.Fecha) } ;

                if(precios.FirstOrDefault().Valor != producto.Precio.Valor)
                {
                    Precio precio = new Precio(){ IdProducto = producto.Id, Valor = producto.Precio.Valor, Fecha = DateTime.Today};
                    Context.Entry(precio).State = EntityState.Added;
                }

                Context.SaveChanges();
                return new Result() { Success = "Producto modificado correctamente" };
            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }
    }
}
