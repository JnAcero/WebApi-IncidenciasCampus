using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Ciudad:BaseEntity
    {
        [MaxLength(100)]
        public string Nombre { get; set; }=null!;
        public int DptoId { get; set; }
        [ForeignKey("DptoId")]
        public Dpto Departamento { get; set; }=null!;
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}