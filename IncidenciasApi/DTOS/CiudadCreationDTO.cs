using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class CiudadCreationDTO
    {
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
    }
}