using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class IncidenciaSoftware
    {
        public int IncidenciaId { get; set; }
        public Incidencia Incidencia { get; set; }=null!;
        public int SoftwareId { get; set; }
        public Software Software { get; set; }=null!;
        public string Descripcion { get; set; }=null!;
        
    }
}