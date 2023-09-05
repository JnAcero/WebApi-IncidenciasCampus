

using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface IUsuario : IGenericRepository<Usuario>
    {
        Task<Usuario> FindUserByUserName(string userName);
        Task<Usuario> FindByUserNameAndPassword(string username, string password);
        
    }
}