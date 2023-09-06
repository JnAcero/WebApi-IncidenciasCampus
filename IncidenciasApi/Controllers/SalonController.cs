using Dominio.Models;
using AutoMapper;
using Dominio.Interfaces;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;
using IncidenciasApi.Helpers;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    //[Route("api/controller/salones")]
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
        [HttpGet]
        public async Task<ActionResult> GetSalones()
        {
            var salones = await _unitOfWork.Salones.GetAllAsync();
            var salonesDTO = _mapper.Map<SalonDTO[]>(salones);
            return Ok(salonesDTO);
        } 
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditSalon(int id, SalonCreationDTO salonDto)
        {
            var salon = await _unitOfWork.Salones.GetByIdAsync(id);
            if(salon is null)
            {
                return NotFound();
            }
            salon.Id =id;
            salon.NombreSalon = salonDto.NombreSalon;
            salon.CantidadEquipos = salonDto.CantidadEquipos;
            var area = await _unitOfWork.Areas.GetByIdAsync(salonDto.AreaId);
            if(area is null)
            {
                return NotFound("el id del area que ingreso no existe");
            }
            salon.Area = area;
            salon.AreaId = salonDto.AreaId;
            await _unitOfWork.Save();
            return Ok(salon); 
        }
        
        //Version moderna para eliminar de la base de datos, ejecuta una sola query
        [MapToApiVersion("1.1")]
        [HttpDelete("V1.1/{id:int}")]
        public async Task<ActionResult> DeleteSalon(int id)
        {
            var filasAlteradas = await _unitOfWork.Salones.ExecuteDeleteAsync(x => x.Id == id);
            if(filasAlteradas ==  0)
            {
                return NotFound();
            }

            return NoContent();
        }
         
    }
}