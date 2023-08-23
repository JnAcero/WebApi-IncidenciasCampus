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
    [Route("api/controller/EquipoSoftware")]
    public class SoftwareEquipoController : BaseApiController
    {
        public SoftwareEquipoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("varios")]
        public async Task<ActionResult> PostSoftwaresEquipos(SoftwareEquipoCreationDTO[] softwaresEquiposDtos)
        { 
            var softwaresEquipos = _mapper.Map<EquipoSoftware[]>(softwaresEquiposDtos);
            _unitOfWork.EquiposSoftwares.AddRange(softwaresEquipos);
            await _unitOfWork.Save();
            return Ok(softwaresEquipos);
        }
    }
}