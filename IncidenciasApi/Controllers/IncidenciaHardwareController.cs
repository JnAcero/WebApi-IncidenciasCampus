
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using IncidenciasApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [Route("api/controller/IncidenciaHarware")]
    public class IncidenciaHardwareController : BaseApiController
    {
        public IncidenciaHardwareController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
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

    }
}