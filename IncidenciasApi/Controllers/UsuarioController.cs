using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using IncidenciasApi.DTOS;
using IncidenciasApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
     [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class UsuarioController : BaseApiController
    {
        private readonly IUserService _userService;
        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService) : base(unitOfWork, mapper)
        {
            _userService = userService;
        }
        [HttpPost("Registro")]
        public async Task<dynamic> SignInUser(RegisterDTO registerDto)
        {
            var respuesta = await _userService.RegisterAsync(registerDto);
            return respuesta;
        }
        [HttpPost("login")]
        public async Task<dynamic> LoginUser(LoginDTO loginDto)
        {
            var respuesta = await _userService.LoginAsync(loginDto);
            return respuesta;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users= await _unitOfWork.Usuarios.GetAllAsync();
            return Ok(users);
        }
       /*  [HttpPut]
        public async Task<ActionResult> */
    }
}