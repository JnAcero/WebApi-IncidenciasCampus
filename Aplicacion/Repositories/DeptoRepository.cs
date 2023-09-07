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
    public class DeptoRepository : GenericRepository<Dpto>, IDpto
    {
        public DeptoRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
         public override async Task<IEnumerable<Dpto>> GetAllAsync()
         {
            return await  _context.Dptos.Include( d =>d.Ciudades).ToListAsync();
         }
        
    }
}