using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class ComponenteHIncidenciaRepository : GenericRepoA<IncidenciaComponenteH>, IComponenteHIncidencia
    {
        public ComponenteHIncidenciaRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
    }
}