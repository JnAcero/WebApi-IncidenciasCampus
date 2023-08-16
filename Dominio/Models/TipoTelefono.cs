using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TipoTelefono:BaseEntity
    {
    [MaxLength(50)]
    public string Tipo { get; set; } = null!;
    public ICollection<TelefonoTrainer> Telefonos { get; set; } = null!;
    }
}