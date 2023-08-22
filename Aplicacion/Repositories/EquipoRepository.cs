
using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace Aplicacion.Repositories
{

    public class EquipoRepository : GenericRepository<Equipo>, IEquipo
    {
        public EquipoRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
    }
}