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
         public  async Task<(int totalRegistros, IEnumerable<Trainer> registros)> GetAllAsyncT(int pageIndex, int pageSize, string Search)
         {
            var query = _context.Trainers as IQueryable<Trainer>;
            if(!string.IsNullOrEmpty(Search))
            {
                query = query.Where(t =>t.Nombres.Contains(Search) || t.Apellidos.Contains(Search));
            }
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                        .Include(r => r.EmailsTrainer)
                                        .Include(r => r.TelefonosTrainer)
                                        .Include(r =>r.ContactosTrainers)
                                        .Skip((pageIndex-1)*pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return (totalRegistros,registros);
         }
         public async override Task<IEnumerable<Trainer>> GetAllAsync()
         {
            return await _context.Trainers
            .Include(t =>t.EmailsTrainer)
            .Include(t =>t.TelefonosTrainer)
            .Include(t =>t.ContactosTrainers)
            .ToListAsync();
         }
    }
}