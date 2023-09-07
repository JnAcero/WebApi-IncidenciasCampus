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
        public async Task<ActionResult> GetEquiposDtos()
        {
            var equipos = await _unitOfWork.Equipos.GetAllAsync();
            var equiposDtos =  equipos.Select(x => new
            {
                Id = x.Id,
                Codigo = x.Codigo,
                FechaActualizacion = x.FechaActualizacion,
                SistemaOperativo = x.SistemaOperativo,
                EspecificacionesTecnicas = x.EspecificacionesTecnicas,
                SalonId = x.SalonId,
                Salon = x.Salon != null ? x.Salon.NombreSalon : "Sin información",
                ComponentesHardware = x.ComponentesHardware.Select(ch =>new {id = ch.Id, codigo = ch.Codigo,marca = ch.Marca,estado=ch.Estado,fechaMantenimiento = ch.FechaMantenimiento, tipoHardware = ch.TipoHardware.NombreHardware}),
                ComponentesSoftware =x.EquiposSoftwares.Select(cs =>new{id = cs.SoftwareId,nombre = cs.Software.Nombre,version = cs.Version, fechaActualizacion= cs.FechaActualizacion, tipoSoftware = cs.Software.TipoSoftware})
            }).ToList();
          
             return Ok(equiposDtos);
        }

       
        [HttpGet("paginacion/V1.1")]
         [MapToApiVersion("1.1")]
        public async Task<ActionResult> GetEquiposconPaginacion([FromQuery] Params equipoParams)
        {
            var equipos = await _unitOfWork.Equipos.GetAllAsyncPaginacion(equipoParams.PageIndex, equipoParams.PageSize,equipoParams.Search);
            var paginacionEquipos = new Pager<Equipo>(equipos.registros, equipos.totalRegistros, equipoParams.PageIndex, equipoParams.PageSize, equipoParams.Search);
            return Ok(paginacionEquipos);
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