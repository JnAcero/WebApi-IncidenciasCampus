using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Incidencia
    {
        public int Id { get; set; }
        public int GravedadIncidenciaId { get; set; }
        public GravedadIncidencia GravedadIncidenciaIncidencia { get; set; } = null!;
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; } = null!;
        public int CategoriaId { get; set; }
        public CategoriaIncidencia CategoriaIncidencia { get; set; } = null!;
        public int IdTrainer { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
        public string ? EstadoIncidencia {get; set;}
        public ICollection<IncidenciaComponenteH> IncidenciasComponentesH { get; set; } = new List<IncidenciaComponenteH>();
        public ICollection<IncidenciaSoftware> IncidenciasSoftwares { get; set; } = new List<IncidenciaSoftware>();
    }
}