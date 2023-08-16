using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Incidencia:BaseEntity
    {
       
        public int GravedadIncidenciaId { get; set; }
        [ForeignKey("GravedadIncidenciaId")]
        public GravedadIncidencia GravedadIncidenciaIncidencia { get; set; } = null!;
        public int EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public Equipo Equipo { get; set; } = null!;
        public int CategoriaId { get; set; }
         [ForeignKey("CategoriaId")]
        public CategoriaIncidencia CategoriaIncidencia { get; set; } = null!;
        public int TrainerId { get; set; }
         [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
        public string ? EstadoIncidencia {get; set;}
        public ICollection<IncidenciaComponenteH> IncidenciasComponentesH { get; set; } = new List<IncidenciaComponenteH>();
        public ICollection<IncidenciaSoftware> IncidenciasSoftwares { get; set; } = new List<IncidenciaSoftware>();
    }
}