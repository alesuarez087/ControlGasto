using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    //public enum TiposMovimientos { Entrada=1, Salida=0 }

    public interface IMovimiento
    {
        Result GetMovimientos();
        Result GetMovimiento(int id);
        Result Create(Movimiento model);
        Result Update(Movimiento model);
    }

    [Table("Movimientos")]
    public class Movimiento
    {
        [Key]
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Local")]
        public int? IdLocal { get; set; }
        public virtual List<MovimientoProductos> MovimientoProducto { get; set; }
        public virtual Local? Local { get; set; }
        [NotMapped]
        public decimal Valor { get;set; }

    }
}
