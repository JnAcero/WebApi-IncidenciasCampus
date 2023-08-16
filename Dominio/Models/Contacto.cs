using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }=null!;
        public string Telefono { get; set; }=null!;
        public string Parentesco { get; set; }=null!;
        public ICollection<TrainerContacto> ContactosTrainers { get; set; } = new List<TrainerContacto>();

    }
}