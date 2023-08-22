
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
            return await _context.Equipos.Include(x => x.Salon).ToListAsync();
        }
        
    }
}