using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public interface ILocal
    {
        Result GetLocal();
    }

    [Table("Locales")]
    public class Local
    {        
        [Key]
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
    }
}
