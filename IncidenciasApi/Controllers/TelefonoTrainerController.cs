using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidenciasApi.Controllers
{
     [ApiController]
    [Route("api/controller/trainer/telefonos")]
    public class TelefonoTrainerController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TelefonoTrainerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
    }
}