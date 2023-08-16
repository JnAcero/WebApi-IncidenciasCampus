using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TipoSoftware
    {
    public int Id { get; set; }
    public string Tipo { get; set; } = null!;
    public ICollection<Software> Softwares { get; set; } = new List<Software>();
    }
}