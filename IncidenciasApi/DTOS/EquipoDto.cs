using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class EquipoDto
    {
        public int Id { get; set; }
        public string ? Codigo { get; set;}
        public DateTime FechaActualizacion { get; set; }
        
        public string SistemaOperativo { get; set; }=null!;
        
        public string? EspecificacionesTecnicas { get; set; }
        public int SalonId { get; set; }
        public string Salon { get; set; }
    }
}