using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public interface IMarca
    {
        //List<Marca> GetMarcas();
        Result GetMarcas();
        Result Create(Marca marca);
        Result Update(Marca marca);
        Result Delete(int id);

    }

    [Table("Marcas")]
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
