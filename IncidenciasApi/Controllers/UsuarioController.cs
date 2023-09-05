using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using IncidenciasApi.DTOS;
using IncidenciasApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
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
    }
}