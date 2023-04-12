using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public interface ITipoProducto
    {
        //List<Marca> GetMarcas();
        Result GetTiposProducto();
        Result Create(TipoProducto tipo);
        Result Update(TipoProducto tipo);
        Result Delete(int id);

    }

    [Table("TiposProducto")]
    public class TipoProducto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
