

using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using IncidenciasApi.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace IncidenciasApi.Services
{
    public class UserService : IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<Usuario> passwordHasher)
        {
            _jwt = jwt.Value;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public Task<dynamic> LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> RegisterAsync(RegisterDTO registerDTO)
        {        
                var usuarioAVerificar = await _unitOfWork.Usuarios.FindUserByUserName(registerDTO.UserName);
                if (usuarioAVerificar is null)
                {
                    var usuario = new Usuario()
                    {
                        NombreUsuario = registerDTO.UserName,
                        Email = registerDTO.Email,
                        FechaCreacion = DateTime.Now,
                        TrainerId = registerDTO.TrainerId
                    };
                    //var idTemporal = 1;
                    usuario.Password = _passwordHasher.HashPassword(usuario, registerDTO.Password);

                    //idTemporal = usuario.Id;
                    var rolUsuario = await _unitOfWork.Roles.GetByIdAsync(registerDTO.RolId);

                    if (rolUsuario is null)
                    {
                        return new
                        {
                            message = $"El rol con id:{registerDTO.RolId} no existe "
                        };
                    }

                    var datos_Usuario_Rol = new List<UsuarioRol>(){
                        new()
                        {
                            Usuario = usuario,
                            Rol = rolUsuario
                        }
                    };
                    usuario.UsuariosRoles.AddRange(datos_Usuario_Rol);
                    _unitOfWork.Usuarios.Add(usuario);
                    await _unitOfWork.Save();
                    return new 
                    {
                        success = true,
                        message ="Usuario creado exitosamente",
                        result = usuario
                    };
                }else{
                    return new 
                    {
                        success = false,
                        message = "Usuario ya existe",
                        result =""
                    };
                }
            }
         
                /* return new
                {
                    success = false,
                    message =ex.Message.ToString(),
                    result =""
                }; */
        }
    }
