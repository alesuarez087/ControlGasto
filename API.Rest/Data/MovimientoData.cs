using API.Rest.Context;
using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Data
{
    public class MovimientoData : IMovimiento
    {
        private readonly AppDbContext Context;

        public MovimientoData(AppDbContext context)
        {
            this.Context = context;
        }

        public Result GetMovimientos()
        {
            try
            {
                List<Movimiento> movimientos = new List<Movimiento>();

                movimientos = Context.Movimiento.Include(x=>x.Local).OrderByDescending(x => x.Fecha).ToList();

                foreach (Movimiento m in movimientos)
                {
                    m.Valor = 0;
                    m.MovimientoProducto = Context.MovimientoProducto.AsNoTracking().Where(x => x.IdMovimiento == m.Id).ToList();

                    foreach(MovimientoProductos mp in m.MovimientoProducto)
                    {
                        ProductoData pd = new ProductoData(Context);

                        mp.Producto = pd.GetProducto(mp.IdProducto, m.Fecha, m.IdLocal);

                        if (mp.Producto.Precio != null && mp.Unidad != decimal.MinValue)
                        {
                            mp.Valor = Math.Round(mp.Unidad * mp.Producto.Precio.Valor, 2);
                            m.Valor += mp.Valor;
                        }
                    }
                }
                

                return new Result() { Data = movimientos };
                
            }
            catch(Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result GetMovimiento(int id)
        {
            Movimiento movimiento = new Movimiento();

            try
            {               

                movimiento = Context.Movimiento.Include(x => x.Local).Where(x => x.Id == id).FirstOrDefault();

                movimiento.Valor = 0;
                movimiento.MovimientoProducto = Context.MovimientoProducto.AsNoTracking().Where(x => x.IdMovimiento == id).ToList();

                foreach (MovimientoProductos mp in movimiento.MovimientoProducto)
                {
                    ProductoData pd = new ProductoData(Context);

                    mp.Producto = pd.GetProducto(mp.IdProducto, movimiento.Fecha, movimiento.IdLocal);

                    if (mp.Producto.Precio != null && mp.Unidad != decimal.MinValue)
                    {
                        mp.Valor = Math.Round(mp.Unidad * mp.Producto.Precio.Valor, 2);
                        movimiento.Valor += mp.Valor;
                    }
                }


                return new Result() { Data = movimiento };

            }
            catch (Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Create(Movimiento model)
        {
            try
            {
                int id = 0;
                Context.Entry(model).State = EntityState.Added;
                id = Context.SaveChanges();
                foreach (MovimientoProductos mov in model.MovimientoProducto){
                    mov.IdMovimiento = model.Id;
                    Context.Entry(mov).State = EntityState.Added;
                    Context.SaveChanges();
                }

                return new Result() { Success = "Movimiento agregado correctamente" };
            }
            catch(Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }

        public Result Update(Movimiento model)
        {
            try
            {
                Context.Entry(model).State = EntityState.Modified;
                Context.SaveChanges();
                foreach(MovimientoProductos mp in model.MovimientoProducto)
                {
                    List<MovimientoProductos> e = this.Context.MovimientoProducto.Where(x => x.IdMovimiento == mp.IdMovimiento && x.IdProducto == mp.IdProducto).ToList();
                    if (e.Count > 0)
                    {
                        Context.Entry(mp).State = EntityState.Modified;
                        //if (e[0].Peso != mp.Peso)
                        //{
                        //    Context.Entry(mp).State = EntityState.Modified;
                        //    Context.SaveChanges();
                        //}
                    }
                    else
                    {
                        Context.Entry(mp).State = EntityState.Added;
                    }
                    Context.SaveChanges();

                }
                return new Result() { Success = "Movimiento editado correctamente" };
            }
            
            catch(Exception ex)
            {
                return new Result() { Error = ex.Message };
            }
        }
    }
}
