using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TrainerContacto
    {
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }=null!;
        public int ContactoId  { get; set; }
        public Contacto Contacto { get; set; }=null!;
    }
}