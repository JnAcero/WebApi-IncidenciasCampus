using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class IncidenciaSoftwareDto
    {
       
        public int EquipoSoftwareId { get; set; }
        public string Descripcion { get; set; }=null!;
    }
}