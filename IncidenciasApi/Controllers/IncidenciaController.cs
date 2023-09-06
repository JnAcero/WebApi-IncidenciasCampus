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
    public class IncidenciaController : BaseApiController
    {
        public IncidenciaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpGet("getByIdTrainer/{id:int}")]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidenciasByTrainer(int id)
        {
            var incidencias = await _unitOfWork.Incidencias.GetIncidenciasByIdTrainer(id);
            if(incidencias is null){
                return NotFound();
            }
           return  Ok(incidencias);
            
        }
        [HttpGet("getByIdSalon/{id:int}")]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidenciasByIdSalon(int id)
        {
               var incidencias = await _unitOfWork.Incidencias.GetIncideciasByIdSalon(id);
               if (incidencias is null){
                return NotFound();
               }
               return Ok(incidencias);
        }
        [HttpPut("{id:int}/estado")]
        public async Task<ActionResult<Incidencia>> PutEstadoIncidencia(int id,PutIncidenciaDTO estadoIncidenciaDto)
        {
            var incidencia = await _unitOfWork.Incidencias.GetIncidenciaById(id);
            if(incidencia is null){
                return NotFound();
            }
            incidencia.EstadoIncidencia = estadoIncidenciaDto.EstadoIncidencia;
            await _unitOfWork.Save();
            return Ok(incidencia);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSalon(int id)
        {
            var filasAlteradas = await _unitOfWork.Incidencias.ExecuteDeleteAsync(x => x.Id == id);
            if(filasAlteradas ==  0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}