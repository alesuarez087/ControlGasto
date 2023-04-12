using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{    
    public interface IProducto
    {
        Result GetProductos();
        Result GetProductos(DateTime fecha, int idLocal);
        Result GetProductos(DateTime fecha);
        Producto GetProducto(int id, DateTime fecha, int? idLocal);
        Result Create(Producto producto);
        Result Update(Producto producto);
        Result Delete(int id);
    }

    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Marca")]
        public int IdMarca { get; set; }

        [ForeignKey("TipoProducto")]
        public int IdTipoProducto { get; set; }
        
        [ForeignKey("Unidad")]
        public int IdUnidad { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Precio Precio { get; set; }
        public virtual Unidad Unidad { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }

        public virtual List<MovimientoProductos> MovimientoProducto { get; set; }
    }
}
