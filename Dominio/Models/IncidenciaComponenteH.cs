using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class IncidenciaComponenteH
    {
        public int IncidenciaId { get; set; }
        [ForeignKey("IncidenciaId")]
        public Incidencia Incidencia{ get; set; }=null!; 
        public int ComponenteHardwareId { get; set; }
        [ForeignKey("ComponenteHardwareId")]
        public ComponenteHardware ComponenteH { get; set; }=null!;
        [MaxLength(500)]
        public string Descripcion { get; set; }=null!;
    }
}