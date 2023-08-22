using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class CompHardwareCreationDTO
    {
        public string Codigo { get; set; } = null!;

        public string? Marca { get; set; }

        public string? Estado { get; set; }
       // public DateTime FechaMantenimiento { get; set; }

        public string Descripcion { get; set; } = null!;
        public int TipoHardwareId { get; set; }


        public int EquipoId { get; set; }

    }
}