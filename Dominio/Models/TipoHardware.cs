using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TipoHardware:BaseEntity
    {
    [MaxLength(50)]
    public string NombreHardware { get; set; } = null!;
     public ICollection<ComponenteHardware> Hardwares { get; set; } = new List<ComponenteHardware>();
    }
}