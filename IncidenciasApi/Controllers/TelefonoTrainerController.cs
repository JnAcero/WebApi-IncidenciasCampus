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
  
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    //[Route("api/controller/trainer/telefonos")]
    public class TelefonoTrainerController : BaseApiController
    {
        public TelefonoTrainerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("varios")]
        public async Task<ActionResult> PostTelefonosTrainer(TelefonoTrainerCreationDTO[] telefonosDtos)
        {
            var telefonoTrainers = _mapper.Map<TelefonoTrainer[]>(telefonosDtos);
            _unitOfWork.TelefonosTrainers.AddRange(telefonoTrainers);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}