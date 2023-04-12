using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public interface IUnidad
    {
        Result GetUnidad();
        Result Create(Unidad unidad);
        Result Update(Unidad unidad);
        Result Delete(int id);
    }

    [Table("Unidades")]
    public class Unidad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Valor { get; set; }

        //public virtual Producto[] Producto { get;set; }
    }
}
