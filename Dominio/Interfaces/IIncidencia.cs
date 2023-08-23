using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface IIncidencia:IGenericRepository<Incidencia>
    {
         Task<IEnumerable<Incidencia>> GetIncidenciasHardware();
        Task<IEnumerable<Incidencia>> GetIncidenciasSoftware();
       Task<Incidencia> GetIncidenciaById(int id);
        Task<Incidencia> GetIncidenciaHardwareById(int id);
        Task<Incidencia> GetIncidenciasSoftwareById(int id);
        Task<IEnumerable<Incidencia>> GetIncidenciasByIdTrainer(int id);
        Task<IEnumerable<Incidencia>> GetIncideciasByIdSalon(int id);
        
    }
}