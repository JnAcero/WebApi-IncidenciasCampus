using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Models;
using IncidenciasApi.DTOS;

namespace IncidenciasApi.Perfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Trainer,TrainerCreationDTO>()
            .ForMember(x =>x.Nombre , t =>t.MapFrom(src =>src.Nombres))
            .ForMember(x =>x.Apellido , t =>t.MapFrom(src =>src.Apellidos))
            .ReverseMap();
            CreateMap<EmailTrainer,EmailTrainerCreationDTO>().ReverseMap();

        }
    }
}