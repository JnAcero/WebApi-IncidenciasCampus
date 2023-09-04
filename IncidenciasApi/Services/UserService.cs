

using Dominio.Models;
using IncidenciasApi.DTOS;

namespace IncidenciasApi.Services
{
    public class UserService : IUserService
    {
        public Task<dynamic> LoginAsync(LoginDTO loginDTO)
        {
           throw new NotImplementedException();
        }

         public Task<dynamic> RegisterAsync(RegisterDTO registerDTO)
        {
           /*  var usuario = new Usuario(){
                NombreUsuario = registerDTO.UserName,
                Email = registerDTO.Email,
                FechaCreacion = DateTime.Now,
                TrainerId = registerDTO.TrainerId
            };  */
                 throw new NotImplementedException();
        }
    }
}