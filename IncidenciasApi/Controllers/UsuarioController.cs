using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
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
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignInUser(RegisterDTO registerDto)
        {
            var respuesta = await _userService.RegisterAsync(registerDto);
            if(respuesta.success == false)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
        [HttpPost("login")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LoginUser(LoginDTO loginDto)
        {
            var respuesta = await _userService.LoginAsync(loginDto);
             if(respuesta.success == false)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
        [HttpGet]  
        [Authorize(Roles="Admin")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllUsers()
        {
            var users= await _unitOfWork.Usuarios.GetAllAsync();
            return Ok(_mapper.Map<GetUsuarioDto[]>(users));
        }
        [HttpPut("{id:int}")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutUser(int id, EditUsuarioDTO editUsuarioDto)
        {
            Usuario existingUser = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if(existingUser == null)
            {
                return NotFound();
            }
            var usuario = _mapper.Map<Usuario>(editUsuarioDto);
            usuario.Id =id;
            usuario.Password = _userService.HashPaswordOfUser(usuario);
            _userService.UpdateAndSaveUserAsync(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteSalon(int id)
        {
            var filasAlteradas = await _unitOfWork.Usuarios.ExecuteDeleteAsync(x => x.Id == id);
            if(filasAlteradas ==  0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}