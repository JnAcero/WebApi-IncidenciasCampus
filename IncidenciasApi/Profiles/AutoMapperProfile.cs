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
            CreateMap<TelefonoTrainer,TelefonoTrainerCreationDTO>().ReverseMap();
            CreateMap<Salon,SalonCreationDTO>().ReverseMap();
            CreateMap<IncidenciaHardwareCreationDTO,Incidencia>()
            .ForMember(x =>x.GravedadIncidenciaId,opt=>opt.MapFrom(src =>src.GravedadIncidenciaId))
             .ForMember(x =>x.TrainerId,opt=>opt.MapFrom(src =>src.TrainerId))
              .ForMember(x =>x.CategoriaId,opt=>opt.MapFrom(src =>src.CategoriaId))
               .ForMember(x =>x.EquipoId,opt=>opt.MapFrom(src =>src.EquipoId))
                .ForMember(x =>x.FechaReporte,opt=>opt.MapFrom(src =>src.FechaReporte))
                 .ForMember(x =>x.IncidenciasComponentesH,opt=>opt.Ignore())
            .ReverseMap();
            CreateMap<IncidenciaComponenteH,IncidenciaHardwareCreationDTO>().ReverseMap();
            CreateMap<IncidenciaComponenteH,ComponenteHardware>().ReverseMap();
            CreateMap<Equipo,EquipoCreationDTO>().ReverseMap();
            CreateMap<ComponenteHardware,CompHardwareCreationDTO>().ReverseMap();
            CreateMap<IncidenciaSoftwareCreationDTO,Incidencia>()
            .ForMember(x => x.IncidenciasComponentesH,opt =>opt.Ignore())
            .ForMember(x => x.IncidenciasSoftwares,opt =>opt.Ignore())
            .ReverseMap();
            CreateMap<SoftwareEquipoCreationDTO,EquipoSoftware>().ReverseMap();

            CreateMap<GetUsuarioDto,Usuario>().ReverseMap();
            CreateMap<UsuarioRolDTO,UsuarioRol>().ReverseMap();
            CreateMap<RolDto,Rol>()
            .ForMember(r =>r.Nombre ,opc => opc.MapFrom(src =>src.NombreRol))
            .ReverseMap();

            CreateMap<EditUsuarioDTO, Usuario>().ReverseMap();

            CreateMap<SalonDTO,Salon>()
                .ForMember(s =>s.AreaId,opc =>opc.Ignore())
                .ReverseMap();  
            CreateMap<AreaDTO,Area>()
                .ForMember(a =>a.Id, opc =>opc.MapFrom(src =>src.AreaId))
                .ReverseMap();


        }
    }
}