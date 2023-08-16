using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Salon
    {
         public int Id { get; set; }
        public string NombreSalon { get; set; } = null!;
        public int CantidadEquipos { get; set; }
        public int AreaId { get; set; }
        public Area Area {get; set; } = null!;
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
    }
}