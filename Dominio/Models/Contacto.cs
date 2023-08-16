using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Contacto:BaseEntity
    {
         [MaxLength(100)]
        public string Nombre { get; set; }=null!;
         [MaxLength(20)]
        public string Telefono { get; set; }=null!;
         [MaxLength(50)]
        public string Parentesco { get; set; }=null!;
        public ICollection<TrainerContacto> ContactosTrainers { get; set; } = new List<TrainerContacto>();

    }
}