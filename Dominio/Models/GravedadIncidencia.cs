using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class GravedadIncidencia:BaseEntity
    {
    [MaxLength(50)]
    public string Gravedad { get; set; } = null!;
    public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
    }
}