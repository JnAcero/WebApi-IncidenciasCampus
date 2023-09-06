using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class SalonDTO
    {
        public int Id { get; set; }
        public string NombreSalon { get; set; } = null!;
        public int CantidadEquipos { get; set; }
        public AreaDTO Area {get; set; } = null!;
    }
}