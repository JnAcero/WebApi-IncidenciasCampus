
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Seeding
{
    public class SeedingInicial
    {
      
        public static void Seed(ModelBuilder modelBuilder)
        {
            var telePersonal = new TipoTelefono()
            {
                Id = 1,
                Tipo = "Telefono personal"
            };
            var telEmpresarial = new TipoTelefono()
            {
                Id = 2,
                Tipo = "Telefono empresarial"
            };
            modelBuilder.Entity<TipoTelefono>().HasData(telEmpresarial, telePersonal);

            var emailPersonal = new TipoEmail()
            {
                Id = 1,
                Tipo = "Email Personal"

            };
            var emailEmpresarial = new TipoEmail()
            {
                Id = 2,
                Tipo = "Email Empresarial"
            };
            modelBuilder.Entity<TipoEmail>().HasData(emailPersonal, emailEmpresarial);

            var colombia = new Pais(){
                Id = 1,
                Nombre = "Colombia",
            };
            var santander = new Dpto(){
                Id=1,
                Nombre = "Santander",
                PaisId = colombia.Id
            };
            var bucaramanga = new Ciudad(){
                Id = 1,
                Nombre = "Bucaramanga",
                DptoId = santander.Id
            };
            var florida = new Ciudad(){
                Id = 2,
                Nombre = "Floridablanca",
                DptoId = santander.Id
            };
            var giron = new Ciudad(){
                Id = 3,
                Nombre = "Giron",
                DptoId = santander.Id
            };
            var piedecuesta = new Ciudad(){
                Id = 4,
                Nombre = "Piedecuesta",
                DptoId = santander.Id
            };
            modelBuilder.Entity<Pais>().HasData(colombia);
            modelBuilder.Entity<Dpto>().HasData(santander);
            modelBuilder.Entity<Ciudad>().HasData(bucaramanga, florida, giron,piedecuesta);
        }

    }
}