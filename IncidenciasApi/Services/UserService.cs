

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using IncidenciasApi.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<dynamic> LoginAsync(LoginDTO loginDTO)
        {
            var usuario = await _unitOfWork.Usuarios.FindUserByUserName(loginDTO.UserName);
            bool UsuarioIsVerified = VerifyPassword(usuario, loginDTO.Password);
            if (UsuarioIsVerified && (usuario is not null))
            {
                JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                return new
                {
                    success = true,
                    message = "Ok,Verificado",
                    result = new
                    {
                        Id = usuario.Id,
                        nombreUsuario = usuario.NombreUsuario,
                        email = usuario.Email,
                         usuariosRoles = usuario.UsuariosRoles,
                    },
                   
                    token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas para el usuario",
                    result = ""
                };
            }
        }
        private bool VerifyPassword(Usuario usuario, string passwordToCompare)
        {
            var passwordVerificationResult = PasswordVerificationResult.Failed;
            try
            {
                passwordVerificationResult = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, passwordToCompare);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return passwordVerificationResult == PasswordVerificationResult.Success;
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
                    TrainerId = registerDTO.TrainerId,
                };

                usuario.Password = _passwordHasher.HashPassword(usuario, registerDTO.Password);

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
                    message = "Usuario creado exitosamente",
                    result = new
                    {
                        Id = usuario.Id,
                        nameUser = usuario.NombreUsuario,
                        email = usuario.Email
                    }
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Usuario ya existe",
                    result = ""
                };
            }
        }
        private JwtSecurityToken CreateJwtToken(Usuario usuario)
        {
            var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub , usuario.NombreUsuario),
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("username", usuario.NombreUsuario),
                    new Claim("email", usuario.Email)
                };
            var usuariosRoles = usuario.UsuariosRoles;
            var roleClaims = new List<Claim>();
            foreach (var usuarioRol in usuariosRoles)
            {
                roleClaims.Add(new Claim("role", usuarioRol.Rol.Nombre));
            }
            claims.AddRange(roleClaims);

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signInCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var JwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signInCredentials
            );
            return JwtSecurityToken;
        }
        public async void UpdateAndSaveUserAsync(Usuario usuario)
        {
            _unitOfWork.Usuarios.Update(usuario);
            await _unitOfWork.Save();
            
        }
        public string HashPaswordOfUser(Usuario usuario)
        {
            return usuario.Password =  _passwordHasher.HashPassword(usuario, usuario.Password);
        }



    }
}
