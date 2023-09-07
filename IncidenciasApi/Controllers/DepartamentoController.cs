

using AutoMapper;
using Dominio.Interfaces;
using Dominio.Models;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
    public class DepartamentoController : BaseApiController
    {
        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
        public async Task<ActionResult> PostDptos(DptoCreationDTO[] dptosDtos)
        {
             var dptos = _mapper.Map<Dpto[]>(dptosDtos);
            _unitOfWork.Departamentos.AddRange(dptos);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<DptoCreationDTO[]>(dptos));
        }
        [HttpGet]
        public async Task<ActionResult> GetDptos()
        {
            var dptos = await _unitOfWork.Departamentos.GetAllAsync();
            var dptosDto =  dptos.Select(d => new {
                Id = d.Id,
                Nombre = d.Nombre,
                Ciudades = d.Ciudades.OrderBy(c =>c.Id).Select(c => new{c.Id ,Nombre = c.Nombre}).ToList()
            });
            return Ok(dptosDto);

        }
    }
}