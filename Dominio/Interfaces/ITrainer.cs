using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface ITrainer:IGenericRepository<Trainer>
    {
        Task<Trainer> GetTrainerById(int id);
        Task<(int totalRegistros, IEnumerable<Trainer> registros)> GetAllAsyncT(int pageIndex, int pageSize, string Search);  
    }
}