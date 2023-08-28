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
    //[Route("api/controller/equipos")]
    public class EquipoController : BaseApiController
    {
        public EquipoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("varios")]
        public async Task<ActionResult> PostEquipos(EquipoCreationDTO[] equiposDto)
        {
            var equipos = _mapper.Map<Equipo[]>(equiposDto);
            _unitOfWork.Equipos.AddRange(equipos);
            await _unitOfWork.Save();
            return Ok(equipos);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoDto>>> GetEquiposDtos()
        {
            var equipos = await _unitOfWork.Equipos.GetAllAsync();
            var equiposDtos =  equipos.Select(x => new EquipoDto
            {
                Id = x.Id,
                Codigo = x.Codigo,
                FechaActualizacion = x.FechaActualizacion,
                SistemaOperativo = x.SistemaOperativo,
                EspecificacionesTecnicas = x.EspecificacionesTecnicas,
                SalonId = x.SalonId,
                Salon = x.Salon != null ? x.Salon.NombreSalon : "Sin información"
            }).ToList();
          
             return Ok(equiposDtos);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutEquipo(EquipoCreationDTO equipoDto,int id)
        {
            var equipo = _mapper.Map<Equipo>(equipoDto);
            equipo.Id = id;
            if(equipo is null)
            {
                return NotFound();
            }
            _unitOfWork.Equipos.Update(equipo);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<EquipoCreationDTO>(equipo));
            
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEquipo(int id)
        {
            var equipo =await  _unitOfWork.Equipos.Find(x => x.Id == id);
            if(equipo is null)
            {
                return NotFound();
            }
            _unitOfWork.Equipos.RemoveRange(equipo);
            await _unitOfWork.Save();
            return Ok(equipo);
        }
    }
}