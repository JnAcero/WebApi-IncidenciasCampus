using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Dpto:BaseEntity
    {
        [MaxLength(100)]
        public string Nombre { get; set; }=null!;
        public int PaisId { get; set; }
        [ForeignKey("PaisId")]
        public Pais Pais { get; set; }=null!;
        public ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();
        
    }
}