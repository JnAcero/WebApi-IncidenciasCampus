using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class ComponenteHardware
    {
    public int Id { get; set; }
    public string Codigo { get; set; }=null!;
    public string? Marca { get; set; }
    public string ? Estado { get; set; }
    public DateTime FechaMantenimiento { get; set; }
    public string Descripcion { get; set; }= null!;
    public int TipoHardwareId { get; set;}
    public TipoHardware TipoHardware { get; set; } = null!;
    public int EquipoId { get; set; }
    public Equipo Equipo { get; set; }= null!;
    public ICollection<IncidenciaComponenteH> IncidenciasComponentesH { get; set; } = new List<IncidenciaComponenteH>();
    
    }
}