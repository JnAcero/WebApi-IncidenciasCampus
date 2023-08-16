using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Equipo:BaseEntity
    {
         [MaxLength(20)]
        public string ? Codigo { get; set;}
        public DateTime FechaActualizacion { get; set; }
         [MaxLength(50)]
        public string SistemaOperativo { get; set; }=null!;
         [MaxLength(280)]
        public string? EspecificacionesTecnicas { get; set; }
        public int SalonId { get; set; }
        [ForeignKey("SalonId")]
        public Salon Salon { get; set; }=null!;
         public ICollection<ComponenteHardware> ComponentesHardware { get; set; } = new List<ComponenteHardware>();
         public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
         public ICollection<EquipoSoftware> EquiposSoftwares { get; set; } = new List<EquipoSoftware>();

    }
}