

using Dominio.Interfaces;
using Dominio.Models;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class SalonRepository : GenericRepository<Salon>, ISalon
    {
        public SalonRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
    }
}