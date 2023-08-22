using Dominio.Models;
using AutoMapper;
using Dominio.Interfaces;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;
using IncidenciasApi.Helpers;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [Route("api/controller/salones")]
    public class SalonController : BaseApiController
    {
        public SalonController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
        public async Task<ActionResult> PostSalones(SalonCreationDTO[] salonesDto)
        {
            try{
            var salones =_mapper.Map<Salon[]>(salonesDto);
            _unitOfWork.Salones.AddRange(salones);
            await _unitOfWork.Save();
            return Ok();
            }
            catch(Exception ex)
            {
                 var response  = new ErrorMessage(){
                     Message = "Ha ocurrido un problema con la creacion de las entidades",
                    ErrorCode = 500
                };
                return StatusCode(500,response);
            }
        }
    }
}