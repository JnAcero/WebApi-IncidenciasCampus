
using Aplicacion.Repositories;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiIncidenciasDbContext _context;
        private  TrainerRepository _trainers;
        private  IncidenciaRepository _incidencias;
        private  SoftwareRepository _softwares;
        private  ComponenteHRepository _componentesH;
        private  SoftwareIncidenciaRepository _softwaresIncidencias;
        private  ComponenteHIncidenciaRepository _componentesHIncidencias;
        private EmailTrainerRepository _emailsTrainers;
        private TelefonoTrainerRepository _telefonosTrainers;


        public UnitOfWork(ApiIncidenciasDbContext context)
        {
            _context = context;
        }

        public ITrainer Trainers {
            get{
                _trainers ??= new TrainerRepository(_context);
                return _trainers;
            }
        }

        public ISoftware Softwares {
            get{
                _softwares ??= new SoftwareRepository(_context);
                return _softwares;
            }
        }

        public ISoftwareIncidencia SoftwaresIncidencias {
            get{
                _softwaresIncidencias ??= new SoftwareIncidenciaRepository(_context);
                return _softwaresIncidencias;
            }
        }

        public IIncidencia Incidencias {
            get{
                _incidencias ??= new IncidenciaRepository(_context);
                return _incidencias;
            }
        }

        public IComponenteH ComponentesHardware {
            get{
                _componentesH ??= new ComponenteHRepository(_context);
                return _componentesH;
            }
        }

        public IComponenteHIncidencia ComponentesHIncidencias {
            get{
                _componentesHIncidencias ??= new ComponenteHIncidenciaRepository(_context);
                return _componentesHIncidencias;
            }
        }
        public IEmailTrainer EmailsTrainers{
            get{
                _emailsTrainers ??= new EmailTrainerRepository(_context);
                return _emailsTrainers;
            }
        }
        public ITelefonoTrainer TelefonosTrainers{
            get{
                _telefonosTrainers ??= new TelefonoTrainerRepository(_context);
                return _telefonosTrainers;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}