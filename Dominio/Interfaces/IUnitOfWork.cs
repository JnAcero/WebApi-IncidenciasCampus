

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
        Task<int> Save ();
    }

   
}