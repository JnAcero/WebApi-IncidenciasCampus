using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Models;
using Dominio.Interfaces;
using IncidenciasApi.DTOS;
using Microsoft.AspNetCore.Mvc;
using IncidenciasApi.Helpers;

namespace IncidenciasApi.Controllers
{
    [ApiController]
    // [Route("api/controller/trainer")]
    public class TrainerController : BaseApiController
    {
        public TrainerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        public async Task<ActionResult> PostTrainer(TrainerCreationDTO trainerDto)
        {
            var trainer = _mapper.Map<Trainer>(trainerDto);
            var Id = trainer.Id;
            _unitOfWork.Trainers.Add(trainer);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpPost("varios")]
        public async Task<ActionResult> PostTrainers(TrainerCreationDTO[] trainersDto)
        {
            try
            {
                var trainers = _mapper.Map<Trainer[]>(trainersDto);
                _unitOfWork.Trainers.AddRange(trainers);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                var response = new ErrorMessage()
                {
                    Message = "Ha ocurrido un problema con la creacion de las entidades",
                    ErrorCode = 500
                };
                return StatusCode(500, response);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Trainer>> PutTrainer(int id, TrainerCreationDTO trainerDto)
        {
            var trainer = _mapper.Map<Trainer>(trainerDto);
            trainer.Id = id;
            _unitOfWork.Trainers.Update(trainer);
            await _unitOfWork.Save();
            return Ok(trainer);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteTrainer(int id)
        {
            var trainer = await _unitOfWork.Trainers.GetTrainerById(id);
            if (trainer is null)
            {
                return NotFound();
            }
            _unitOfWork.Trainers.Remove(trainer);
            await _unitOfWork.Save();
            return Ok();

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers(int id)
        {
            var trainers = _unitOfWork.Trainers.Find(x => x.Id == id);
            if (trainers is null)
            {
                return NotFound();
            }
            return Ok(trainers);
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainersByName(string nombre)
        {
            var trainers = _unitOfWork.Trainers.Find(x => x.Nombres.Contains(nombre));
            if (trainers is null)
            {
                return NotFound();
            }
            return Ok(trainers);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            var trainers = await _unitOfWork.Trainers.GetAllAsync();
            if(trainers is null){
                return NotFound();
            }
            return Ok(trainers);
           
        }
}
}