using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TelefonoTrainer
    {
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public int TipoTelefonoId { get; set; }
        public TipoTelefono TipoTelefono { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
    }
}