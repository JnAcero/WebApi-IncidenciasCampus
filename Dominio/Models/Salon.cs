using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Salon:BaseEntity
    {
         [MaxLength(30)]
        public string NombreSalon { get; set; } = null!;
        public int CantidadEquipos { get; set; }
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area Area {get; set; } = null!;
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
    }
}