using API.Rest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Marca> Marca { get;set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<MovimientoProductos> MovimientoProducto { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<Local> Local { get; set; }

    }
}
