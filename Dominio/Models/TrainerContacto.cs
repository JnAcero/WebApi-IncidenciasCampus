using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TrainerContacto
    {
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }=null!;
        public int ContactoId  { get; set; }
        [ForeignKey("ContactoId")]
        public Contacto Contacto { get; set; }=null!;
    }
}