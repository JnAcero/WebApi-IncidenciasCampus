
using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
        public CiudadRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades.Include(c =>c.Trainers).Include(c =>c.Departamento). ToListAsync();
        }
    }
}