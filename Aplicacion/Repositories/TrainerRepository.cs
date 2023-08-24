using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainer
    {
        public TrainerRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
         public async Task<Trainer> GetTrainerById(int id)
         {
            return await _context.Trainers.FirstOrDefaultAsync(x => x.Id == id);
         }
    }
}