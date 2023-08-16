using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class EquipoSoftware
    {
        public int EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public Equipo Equipo { get; set; }=null!;
        public int SoftwareId { get; set; }
         [ForeignKey("SoftwareId")]
        public Software Software { get; set; }=null!;
         [MaxLength(20)]
        public string? Version { get; set; }
        public DateTime FechaActualizacion { get; set; }= DateTime.Now;

    }
}