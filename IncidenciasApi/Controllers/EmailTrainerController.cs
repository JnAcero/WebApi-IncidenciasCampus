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
    //[Route("api/controller/trainer/emails")]
    public class EmailTrainerController : BaseApiController
    {
        public EmailTrainerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost("varios")]
        public async Task<ActionResult> PostEmails(EmailTrainerCreationDTO[] emailsTrainerDtos)
        {
            try {
            var emailsTrainer = _mapper.Map<EmailTrainer[]>(emailsTrainerDtos);
            _unitOfWork.EmailsTrainers.AddRange(emailsTrainer);
            await _unitOfWork.Save();
            return Ok();

            }catch(Exception ex){
                var response  = new ErrorMessage(){
                     Message = "Ha ocurrido un problema con la creacion de las entidades",
                    ErrorCode = 500
                };
                return StatusCode(500,response);
            }
            
        }
    }
}