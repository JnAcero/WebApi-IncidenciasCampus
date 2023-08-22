using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class IncidenciaRepository : GenericRepository<Incidencia>, IIncidencia
    {
        public IncidenciaRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
         public override async Task<IEnumerable<Incidencia>> GetAllAsync()
         {
            var actores = _context.Incidencias;
            return await actores.ToListAsync();
         }
         public async Task<IEnumerable<Incidencia>> GetIncidenciasHardware()
         {
            var incidencias = _context.Incidencias.Where( x => x.CategoriaId == 2).Include(x => x.IncidenciasComponentesH);
            return await incidencias.ToListAsync();
         }
         public async Task<IEnumerable<Incidencia>> GetIncidenciasSoftware()
         {
            var incidencias = _context.Incidencias.Where( x => x.CategoriaId == 1).Include(x => x.IncidenciasSoftwares);
            return await incidencias.ToListAsync();

         }
    }
}