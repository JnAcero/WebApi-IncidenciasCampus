

using Dominio.Models;
using IncidenciasApi.DTOS;

namespace IncidenciasApi.Services
{
    public interface IUserService
    {
        Task<IRespuestaDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<IRespuestaDTO> LoginAsync(LoginDTO loginDTO);
        void UpdateAndSaveUserAsync(Usuario usuario);
        string HashPaswordOfUser(Usuario usuario);

        
    }
}