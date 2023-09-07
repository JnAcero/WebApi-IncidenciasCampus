
using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories
{

    public class EquipoRepository : GenericRepository<Equipo>, IEquipo
    {
        public EquipoRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<Equipo>> GetAllAsync()
        {
            return await _context.Equipos
            .Include(x => x.Salon)
            .Include(x =>x.ComponentesHardware)
                .ThenInclude(ch =>ch.TipoHardware)
            .Include(x =>x.EquiposSoftwares)
                .ThenInclude(cs => cs.Software)
            .ToListAsync();
        }

        public async Task<(int totalRegistros, IEnumerable<Equipo> registros)> GetAllAsyncPaginacion(int pageIndex, int pageSize, string Search)
        {
            var query = _context.Equipos as IQueryable<Equipo>;
            if(!string.IsNullOrEmpty(Search))
            {
                query = query.Where(t =>t.Codigo.Contains(Search) || t.SistemaOperativo.Contains(Search));
            }
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                        .Include(r => r.Salon)
                                            .ThenInclude(r =>r.Area)
                                        .Include(r => r.ComponentesHardware)
                                        .Include(r =>r.EquiposSoftwares)
                                        .Skip((pageIndex-1)*pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return (totalRegistros,registros);
        }
    }
}