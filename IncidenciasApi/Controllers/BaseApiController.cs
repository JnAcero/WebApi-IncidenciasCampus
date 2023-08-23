
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    [Route("api/incidencias/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public BaseApiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
             _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}