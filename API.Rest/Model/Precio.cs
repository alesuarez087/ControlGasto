using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public interface IPrecio
    {
        Result GetHistorialPrecios(int id);
        Result Create(Precio precio);
    }
    [Table("PreciosProducto")]
    public class Precio
    {
        [Key, ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public decimal Valor { get; set; }
        [ForeignKey("Local")]
        public int IdLocal { get; set; }

        [NotMapped]
        public decimal Variabilidad { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Local Local { get; set; }
    }
}
