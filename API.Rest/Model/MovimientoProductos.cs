using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public interface IMovimientoProducto
    {
        Result Create(MovimientoProductos model);
    }

    [Table("MovimientoProductos")]
    public class MovimientoProductos
    {
        [Key, ForeignKey("Movimiento")]
        public int IdMovimiento { get; set; }
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public decimal Unidad { get; set; }

        [NotMapped]
        public decimal Valor { get; set; }
        public virtual Movimiento Movimiento { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
