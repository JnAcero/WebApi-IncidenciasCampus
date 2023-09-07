using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using IncidenciasApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    //[Route("api/controller/trainer/emails")]
    public class EmailTrainerController : BaseApiController
    {
        public EmailTrainerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost("varios")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostEmails(EmailTrainerCreationDTO[] emailsTrainerDtos)
        { 
            var emailsTrainer = _mapper.Map<EmailTrainer[]>(emailsTrainerDtos);
            _unitOfWork.EmailsTrainers.AddRange(emailsTrainer);
            await _unitOfWork.Save();
            return Ok();  
        }
    }
}