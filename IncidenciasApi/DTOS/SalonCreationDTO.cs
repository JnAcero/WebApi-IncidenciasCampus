using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class SalonCreationDTO
    {
         public string NombreSalon { get; set; } = null!;
        public int CantidadEquipos { get; set; }
        public int AreaId { get; set; }
    }
}