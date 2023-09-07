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
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
   // [Route("api/controller/EquipoSoftware")]
    public class SoftwareEquipoController : BaseApiController
    {
        public SoftwareEquipoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("varios")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostSoftwaresEquipos(SoftwareEquipoCreationDTO[] softwaresEquiposDtos)
        { 
            var softwaresEquipos = _mapper.Map<EquipoSoftware[]>(softwaresEquiposDtos);
            _unitOfWork.EquiposSoftwares.AddRange(softwaresEquipos);
            await _unitOfWork.Save();
            return Ok(softwaresEquipos);
        }
    }
}