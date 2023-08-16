using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string NumDocumento { get; set; } =null!;
        public string Nombre { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int CiudadId { get; set; } 
        public Ciudad Ciudad { get; set; }
        public ICollection<EmailTrainer> EmailsTrainer { get; set; } = new List<EmailTrainer>();
        public ICollection<TelefonoTrainer> TelefonosTrainer { get; set; } = new List<TelefonoTrainer>();
        public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
         public ICollection<TrainerContacto> ContactosTrainers { get; set; } = new List<TrainerContacto>();
    }
}