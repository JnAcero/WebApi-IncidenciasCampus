
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
    [ApiController]
   // [Route("api/controller/IncidenciaSoftware")]
    public class IncidenciaSoftwareController : BaseApiController
    {
        public IncidenciaSoftwareController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
        public async Task<ActionResult> PostIncidenciaSoftware(IncidenciaSoftwareCreationDTO incidenciasoftwareDto)
        {
            var inc_Software = _mapper.Map<Incidencia>(incidenciasoftwareDto);
            inc_Software.EstadoIncidencia ="Reportada";
            int IdTemporal=1;
            _unitOfWork.Incidencias.Add(inc_Software);
            await _unitOfWork.Save();

            IdTemporal = inc_Software.Id;

            foreach(var item in incidenciasoftwareDto.IncidenciasSoftware)
            {
                var SoftwareIncidencia = new IncidenciaSoftware(){
                   IncidenciaId = IdTemporal,
                   SoftwareId = item.SoftwareId,
                   Descripcion = item.Descripcion
                };
                _unitOfWork.SoftwaresIncidencias.Add(SoftwareIncidencia);
                await _unitOfWork.Save();
            }
            return Ok();

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidenciasSoftware()
        {
            var incidencias = await _unitOfWork.Incidencias.GetIncidenciasSoftware();
            if(incidencias is null)
            {
                return NotFound();
            }
            return Ok(incidencias);
        }
        [HttpGet("getById/{id:int}")]
        public async Task<ActionResult<Incidencia>> GetIncidenciaSoftwareById(int id)
        {
            var incidencia = await _unitOfWork.Incidencias.GetIncidenciasSoftwareById(id);
            if(incidencia is null)
            {
                return NotFound();
            }
            return Ok(incidencia);
        }
         
    }
}