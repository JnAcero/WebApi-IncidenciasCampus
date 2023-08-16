using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class IncidenciaComponenteH
    {
        public int IncidenciaId { get; set; }
        public Incidencia Incidencia{ get; set; }=null!; 
        public int ComponenteHardwareId { get; set; }
        public ComponenteHardware ComponenteH { get; set; }=null!;
        public string Descripcion { get; set; }=null!;
    }
}