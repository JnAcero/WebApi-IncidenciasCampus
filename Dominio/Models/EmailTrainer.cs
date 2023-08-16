using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class EmailTrainer
    {
    public int TrainerId { get; set; }
    [ForeignKey("TrainerId")]
    public Trainer Trainer { get; set; } = null!;
    public int TipoEmailId { get; set; }
     [ForeignKey("TipoEmailId")]
    public TipoEmail TipoEmail { get; set; } =null!;
     [MaxLength(200)]
    public string Email { get; set; }=null!;
    }
}