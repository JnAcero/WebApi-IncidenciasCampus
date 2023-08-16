using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Codigo { get; set;}
        public DateTime FechaActualizacion { get; set; }=DateTime.Now;
        public string SistemaOperativo { get; set; }=null!;
        public string? EspecificacionesTecnicas { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }=null!;
         public ICollection<ComponenteHardware> ComponentesHardware { get; set; } = new List<ComponenteHardware>();
         public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
         public ICollection<EquipoSoftware> EquiposSoftwares { get; set; } = new List<EquipoSoftware>();

    }
}