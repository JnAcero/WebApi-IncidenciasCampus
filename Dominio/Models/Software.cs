using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Software:BaseEntity
    {
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int TipoSofwareId { get; set; }
        [ForeignKey("TipoSofwareId")]
        public TipoSoftware TipoSoftware { get; set; } = null!;
         public ICollection<EquipoSoftware> EquiposSoftwares { get; set; } = new List<EquipoSoftware>();
          public ICollection<IncidenciaSoftware> IncidenciasSoftwares { get; set; } = new List<IncidenciaSoftware>();

    }
}