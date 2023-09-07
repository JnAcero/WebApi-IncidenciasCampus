
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using IncidenciasApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    //[Route("api/controller/IncidenciaHardware")]
    public class IncidenciaHardwareController : BaseApiController
    {
        public IncidenciaHardwareController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
        [Authorize(Roles="Admin,Trainer")]
        public async Task<ActionResult> PostIncidenciaHardware(IncidenciaHardwareCreationDTO incidenciaHardwareDto)
        {
                var incidenciaH = new Incidencia(){
                    GravedadIncidenciaId= incidenciaHardwareDto.GravedadIncidenciaId,
                    TrainerId = incidenciaHardwareDto.TrainerId,
                    CategoriaId = incidenciaHardwareDto.CategoriaId,
                    EquipoId = incidenciaHardwareDto.EquipoId,
                    Descripcion = incidenciaHardwareDto.Descripcion,
                    FechaReporte = incidenciaHardwareDto.FechaReporte,
                    EstadoIncidencia = "Reportada"
                };
                int idTemporal = 1;
               // var entidades = new List<IncidenciaComponenteH>();
                _unitOfWork.Incidencias.Add(incidenciaH);
                await _unitOfWork.Save();
                //return Ok();
                idTemporal = incidenciaH.Id;
                
                foreach (var item in incidenciaHardwareDto.IncidenciasHardware)
                {
                    var HardwareIncidencia = new IncidenciaComponenteH()
                    {
                        IncidenciaId = idTemporal,
                        ComponenteHardwareId = item.ComponenteHardwareId,
                        Descripcion = item.Descripcion
                    };
                    _unitOfWork.ComponentesHIncidencias.Add(HardwareIncidencia);
                    await _unitOfWork.Save();
                }         
                return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetAllIncidencias()
        {
            var incidencias = await _unitOfWork.Incidencias.GetIncidenciasHardware();
            if(incidencias is null){
                return NotFound();
            }
            return Ok(incidencias);
        }
        [HttpGet("getById/{id:int}")]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidenciaHardwareByID(int id)
        {
            var incidencia = await _unitOfWork.Incidencias.GetIncidenciaHardwareById(id);
            if(incidencia is null)
            {
                return NotFound();           
            }
            return Ok(incidencia);
        }
    }
}