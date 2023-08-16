using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class EquipoSoftware
    {
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }=null!;
        public int SoftwareId { get; set; }
        public Software Software { get; set; }=null!;
        public string? Version { get; set; }
        public DateTime FechaActualizacion { get; set; }= DateTime.Now;

    }
}