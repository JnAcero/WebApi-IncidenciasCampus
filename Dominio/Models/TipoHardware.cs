using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TipoHardware
    {
    public int Id { get; set; }
    public string NombreHardware { get; set; } = null!;
     public ICollection<ComponenteHardware> Hardwares { get; set; } = new List<ComponenteHardware>();
    }
}