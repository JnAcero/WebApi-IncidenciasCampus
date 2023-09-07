
using Aplicacion.Repositories;
using Dominio.Interfaces;
using Dominio.Models;
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
        private SalonRepository _salones;
        private EquipoRepository _equipos;
        private EquipoSoftwareRepository _equiposSoftwares;
        private UsuarioRepository _usuarios;
        private RolRepository _roles;
        private UsuarioRolRepository _usuariosRoles;
        private AreaRepository _areas;
        private CiudadRepository _ciudades;
        private DeptoRepository _dptos;


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
        public ISalon Salones{
            get{
                _salones ??=new SalonRepository(_context);
                return _salones;
            }
        }
        public IEquipo Equipos{
            get{
                _equipos ??=new EquipoRepository(_context);
                return _equipos;
            }
        }
        public IEquipoSoftware EquiposSoftwares{
            get{
                _equiposSoftwares ??= new EquipoSoftwareRepository(_context);
                return _equiposSoftwares;
            }
        }

        public IUsuario Usuarios{
            get{
                _usuarios ??= new UsuarioRepository(_context);
                return _usuarios;
            }

        }

        public IRol Roles{
            get{
                _roles ??= new RolRepository(_context);
                return _roles;
            }
        }

        public IUsuarioRol UsuariosRoles{
            get{
                _usuariosRoles ??= new UsuarioRolRepository(_context);
                return _usuariosRoles;
            }
        }

        public IArea Areas{
            get{
                _areas ??= new AreaRepository(_context);
                return _areas;
            }
        }

        public ICiudad Ciudades{
            get{
                _ciudades ??= new CiudadRepository(_context);
                return _ciudades;
            }
        }

        public IDpto Departamentos{
            get{
                _dptos ??= new DeptoRepository(_context);
                return _dptos;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}