using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class EmailTrainer
    {
    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; } = null!;
    public int TipoEmailId { get; set; }
    public TipoEmail TipoEmail { get; set; } =null!;
    public string Email { get; set; }=null!;
    }
}