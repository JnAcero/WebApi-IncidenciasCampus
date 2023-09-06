

using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class SalonRepository : GenericRepository<Salon>, ISalon
    {
        public SalonRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Salon>> GetAllAsync()
        {
            return await _context.Salones.Include(s => s.Area).ToListAsync();
        }

        public async override Task<Salon> GetByIdAsync(int id)
        {
            return await _context.Salones.Include(s =>s.Area).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}