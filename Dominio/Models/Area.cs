using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Area
    {
    public int Id { get; set; }
    public string NombreArea { get; set; } = null!;
    public string ? Descripcion { get; set; }
    public ICollection<Salon> Salones { get; set; } = new List<Salon>();
    }
}