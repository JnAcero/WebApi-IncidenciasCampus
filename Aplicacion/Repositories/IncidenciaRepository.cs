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
         var incidencias = _context.Incidencias.Where(x => x.CategoriaId == 2).Include(x => x.IncidenciasComponentesH);
         return await incidencias.ToListAsync();
      }
      public async Task<IEnumerable<Incidencia>> GetIncidenciasSoftware()
      {
         var incidencias = _context.Incidencias.Where(x => x.CategoriaId == 1).Include(x => x.IncidenciasSoftwares);
         return await incidencias.ToListAsync();

      }
      public async Task<Incidencia> GetIncidenciaHardwareById(int id)
      {
         var incidencias = _context.Incidencias.Where(x => x.CategoriaId == 2).Include(x => x.IncidenciasComponentesH).FirstOrDefaultAsync(x => x.Id == id);
         return await incidencias;
      }
      public async Task<Incidencia> GetIncidenciasSoftwareById(int id)
      {
         var incidencias = _context.Incidencias.Where(x => x.CategoriaId == 1).Include(x => x.IncidenciasSoftwares).FirstOrDefaultAsync(x => x.Id == id);
         return await incidencias;
      }
      public async Task<IEnumerable<Incidencia>> GetIncidenciasByIdTrainer(int id)
      {
         return await _context.Incidencias.Where(x => x.TrainerId == id)
         .Include(x => x.IncidenciasSoftwares)
         .Include(x => x.IncidenciasComponentesH)
         .ToListAsync();
      }
      public async Task<IEnumerable<Incidencia>> GetIncideciasByIdSalon(int id)
      {
         return await _context.Incidencias.Where(x => x.Equipo.SalonId == id)
         .Include(x => x.IncidenciasSoftwares)
         .Include(x => x.IncidenciasComponentesH)
         .ToListAsync();
      }
      public async Task<Incidencia> GetIncidenciaById(int id)
      {
            return await _context.Incidencias
         .Include(x => x.IncidenciasSoftwares)
         .Include(x => x.IncidenciasComponentesH)
         .FirstOrDefaultAsync(x =>x.Id == id);
      }


   }
}