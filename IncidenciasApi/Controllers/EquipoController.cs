using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
[ApiController]
    [Route("api/controller/equipos")]
    public class EquipoController : BaseApiController
    {
        public EquipoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("varios")]
        public async Task<ActionResult> PostEquipos(EquipoCreationDTO[] equiposDto)
        {
            var equipos = _mapper.Map<Equipo[]>(equiposDto);
            _unitOfWork.Equipos.AddRange(equipos);
            await _unitOfWork.Save();
            return Ok(equipos);
        }
    }
}