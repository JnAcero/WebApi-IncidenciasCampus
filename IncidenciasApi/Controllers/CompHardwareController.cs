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
   // [Route("api/controller/ComponenteHardware")]
    public class CompHardwareController : BaseApiController
    {
        public CompHardwareController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("varios")]
        public async Task<ActionResult> PostCompHardaware(CompHardwareCreationDTO[] hardwaresDtos)
        {
            var hardwares = _mapper.Map<ComponenteHardware[]>(hardwaresDtos);
            _unitOfWork.ComponentesHardware.AddRange(hardwares);
            await _unitOfWork.Save();
            return Ok(hardwares);
        }
    }
}