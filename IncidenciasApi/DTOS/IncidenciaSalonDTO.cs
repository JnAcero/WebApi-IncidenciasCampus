using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class IncidenciaSalonDTO
    {
        public int GravedadIncidenciaId { get; set; }

        public int EquipoId { get; set; }

        public int CategoriaId { get; set; }

        public int TrainerId { get; set; }

        public string? Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }

        public ICollection<IncidenciaSoftwareDto> IncidenciasSoftware {get;set;}= new List<IncidenciaSoftwareDto>();
        public ICollection<ComponenteHardwareDTO> IncidenciasHardware {get;set;}= new List<ComponenteHardwareDTO>();

       

    }
}