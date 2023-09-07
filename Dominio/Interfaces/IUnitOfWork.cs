

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        ITrainer Trainers { get; }
        ISoftware Softwares { get; }
        ISoftwareIncidencia SoftwaresIncidencias { get; }
        IIncidencia Incidencias { get; }
        IComponenteH ComponentesHardware { get; }
        IComponenteHIncidencia ComponentesHIncidencias { get; }
        IEmailTrainer EmailsTrainers { get; }
        ITelefonoTrainer TelefonosTrainers { get; }
        ISalon Salones { get; }
        IEquipo Equipos { get; }
        IEquipoSoftware EquiposSoftwares { get; }
        IUsuario Usuarios { get; }
        IRol Roles { get; }
        IUsuarioRol UsuariosRoles { get; }
        IArea Areas { get; }
        ICiudad Ciudades { get; }
        IDpto Departamentos { get; }
        Task<int> Save ();
    }

   
}