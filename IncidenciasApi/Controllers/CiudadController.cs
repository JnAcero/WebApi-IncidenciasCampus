
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CiudadController : BaseApiController
    {
        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostCiudades(CiudadCreationDTO[] ciudadesDto)
        {
            var ciudades = _mapper.Map<Ciudad[]>(ciudadesDto);
            _unitOfWork.Ciudades.AddRange(ciudades);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<CiudadCreationDTO[]>(ciudades));
        }
        [HttpGet]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult> GetCiudades()
        {
            var ciudades  = await _unitOfWork.Ciudades.GetAllAsync();
            var ciudadesDto = ciudades.Select(c =>new{
                Id = c.Id,
                Nombre = c.Nombre,
                DptoId = c.DptoId,
                NombreDpto = c.Departamento.Nombre,
                Trainers = c.Trainers?.Select(t => new{Id = t.Id, Nombre = t.Nombres})
            });
            return Ok(ciudadesDto);
        }
        [HttpPut("{id:int}")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutCiudades(int id, CiudadCreationDTO ciudadDto)
        {
            if(ciudadDto is null)
            {
                return NotFound();
            }
            var ciudad =_mapper.Map<Ciudad>(ciudadDto);
            ciudad.Id = id;
            _unitOfWork.Ciudades.Update(ciudad);
            await _unitOfWork.Save();
            return Ok(ciudad);
        }

         [HttpDelete("{id:int}")]
         [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCiudad(int id)
        {
            var filasAlteradas = await _unitOfWork.Ciudades.ExecuteDeleteAsync(x => x.Id == id);
            if(filasAlteradas ==  0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}