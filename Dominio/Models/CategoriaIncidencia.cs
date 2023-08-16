using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class CategoriaIncidencia:BaseEntity
    {
    [MaxLength(100)]
    public string Categoria { get; set; } = null!;
    public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
    }
}