using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IArea
    {
        public AreaRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
    }
}