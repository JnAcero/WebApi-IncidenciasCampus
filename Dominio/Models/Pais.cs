using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Pais:BaseEntity
    {
       [MaxLength(50)]
        public string Nombre { get; set; }=null!;
        public ICollection<Dpto> Dptos { get; set; } = new List<Dpto>();
    }
}