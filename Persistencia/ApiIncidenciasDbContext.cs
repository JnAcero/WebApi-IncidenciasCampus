using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Persistencia.Seeding;

namespace Persistencia
{
    public class ApiIncidenciasDbContext : DbContext
    {
        public ApiIncidenciasDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            SeedingInicial.Seed(modelBuilder);
        }
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<CategoriaIncidencia> CategoriasIncidencias => Set<CategoriaIncidencia>();
        public DbSet<Ciudad> Ciudades => Set<Ciudad>();
        public DbSet<ComponenteHardware> ComponentesHardware => Set<ComponenteHardware>();
        public DbSet<Dpto> Dptos => Set<Dpto>();
        public DbSet<EmailTrainer> EmailsTrainers => Set<EmailTrainer>();
        public DbSet<Equipo> Equipos => Set<Equipo>();
        public DbSet<EquipoSoftware> EquipoSSoftwares => Set<EquipoSoftware>();
        public DbSet<GravedadIncidencia> GravedadesIncidencias => Set<GravedadIncidencia>();
        public DbSet<Incidencia> Incidencias => Set<Incidencia>();
        public DbSet<IncidenciaComponenteH> IncidenciasComponentesH => Set<IncidenciaComponenteH>();
        public DbSet<IncidenciaSoftware> IncidenciasSoftwares => Set<IncidenciaSoftware>();
        public DbSet<Pais> Paises => Set<Pais>();
        public DbSet<Salon> Salones => Set<Salon>();
        public DbSet<Software> Softwares => Set<Software>();
        public DbSet<TelefonoTrainer> TelefonosTrainers => Set<TelefonoTrainer>();
        public DbSet<TipoEmail> TiposEmail => Set<TipoEmail>();
        public DbSet<TipoHardware> TiposHardware => Set<TipoHardware>();
        public DbSet<TipoSoftware> TipoSoftware => Set<TipoSoftware>();
        public DbSet<TipoTelefono> TiposTelefono => Set<TipoTelefono>();
        public DbSet<Contacto> Contactos => Set<Contacto>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<TrainerContacto> TrainersContactos => Set<TrainerContacto>();
    }
}