using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TipoEmail
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public ICollection<EmailTrainer> Emails { get; set; } = new List<EmailTrainer>();
    }
}