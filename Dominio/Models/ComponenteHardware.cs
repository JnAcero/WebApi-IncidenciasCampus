using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class ComponenteHardware:BaseEntity
    {
     [MaxLength(30)]
    public string Codigo { get; set; }=null!;
     [MaxLength(100)]
    public string? Marca { get; set; }
     [MaxLength(200)]
    public string ? Estado { get; set; }
    public DateTime FechaMantenimiento { get; set; }
     [MaxLength(280)]
    public string Descripcion { get; set; }= null!;
    public int TipoHardwareId { get; set;}
    [ForeignKey("TipoHardwareId")]
    public TipoHardware TipoHardware { get; set; } = null!;
    public int EquipoId { get; set; }
    [ForeignKey("EquipoId")]
    public Equipo Equipo { get; set; }= null!;
    public ICollection<IncidenciaComponenteH> IncidenciasComponentesH { get; set; } = new List<IncidenciaComponenteH>();
    
    }
}