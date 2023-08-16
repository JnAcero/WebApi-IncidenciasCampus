using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Trainer:BaseEntity
    {
        public string NumDocumento { get; set; } =null!;
        public string Nombre { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime FechaNacimineto { get; set; }
        public int CiudadId { get; set; } 
        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }=null!;
        public ICollection<EmailTrainer> EmailsTrainer { get; set; } = new List<EmailTrainer>();
        public ICollection<TelefonoTrainer> TelefonosTrainer { get; set; } = new List<TelefonoTrainer>();
        public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
         public ICollection<TrainerContacto> ContactosTrainers { get; set; } = new List<TrainerContacto>();
    }
}