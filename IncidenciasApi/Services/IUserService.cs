

using Dominio.Models;
using IncidenciasApi.DTOS;

namespace IncidenciasApi.Services
{
    public interface IUserService
    {
        Task<dynamic> RegisterAsync(RegisterDTO registerDTO);
        Task<dynamic> LoginAsync(LoginDTO loginDTO);
        void UpdateAndSaveUserAsync(Usuario usuario);
        string HashPaswordOfUser(Usuario usuario);

        
    }
}