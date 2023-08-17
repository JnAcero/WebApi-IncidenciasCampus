using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class TelefonoTrainerRepository : GenericRepoA<TelefonoTrainer>,ITelefonoTrainer
    {
        public TelefonoTrainerRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }
    }
}