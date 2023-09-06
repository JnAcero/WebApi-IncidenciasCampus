
using Dominio.Models;
namespace Dominio.Interfaces
{
    public interface IEquipo:IGenericRepository<Equipo>
    {
         Task<(int totalRegistros, IEnumerable<Equipo> registros)> GetAllAsyncPaginacion(int pageIndex, int pageSize, string search);
        
    }

}