using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Area:BaseEntity
    {
    [MaxLength(50)]
    public string NombreArea { get; set; } = null!;
    [MaxLength(100)]
    public string ? Descripcion { get; set; }
    public ICollection<Salon> Salones { get; set; } = new List<Salon>();
    }
}