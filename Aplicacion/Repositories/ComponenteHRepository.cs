using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class ComponenteHRepository : GenericRepository<ComponenteHardware>, IComponenteH
    {
        public ComponenteHRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
    }
}