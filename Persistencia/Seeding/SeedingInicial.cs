
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

            var review1 = new Area(){
                Id = 1,
                NombreArea = "Review 1",
                Descripcion = "Zona de estudio personal al lado de hunters"
            };
             var review2 = new Area(){
                Id = 2,
                NombreArea = "Review 2",
                Descripcion = "Zona de estudio personal al lado de training"
             };
             var training = new Area(){
                Id= 3,
                NombreArea ="Area de Training",
                Descripcion = "Area donde se dan las clases de progrmacion"
             };
             modelBuilder.Entity<Area>().HasData(training,review1,review2);
             var teclado = new TipoHardware(){
                Id=1,
                NombreHardware ="Teclado"
             };
             var mouse = new TipoHardware(){
                Id = 2,
                NombreHardware ="Mouse"
             };
             var diadema = new TipoHardware(){
                Id =3,
                NombreHardware ="Diadema"
             };
             var pantalla = new TipoHardware(){
                Id =4,
                NombreHardware ="Pantalla"
             };
             var cpu = new TipoHardware(){
                Id =5,
                NombreHardware = "CPU"
             };
             var sistema = new TipoSoftware(){
                Id =1,
                Tipo = "Sistema"
             };
              var aplicacion = new TipoSoftware(){
                Id =2,
                Tipo = "Aplicacion"
             };
              var Gestion = new TipoSoftware(){
                Id =3,
                Tipo = "Gestion"
             };
              var Programacion = new TipoSoftware(){
                Id =4,
                Tipo = "Programacion"
             };
              modelBuilder.Entity<TipoHardware>().HasData(teclado,mouse,pantalla,diadema,cpu);
               modelBuilder.Entity<TipoSoftware>().HasData(aplicacion,Gestion,Programacion,sistema);
               var netcore = new Software(){
                Id=1,
                Nombre = ".NET Framework",
                Descripcion ="Framework de Microsoft para desarrollo de microservicios, desarrollo web, entre otros",
                TipoSofwareId = Programacion.Id
               };
                var discord = new Software(){
                Id=2,
                Nombre = "Discord",
                Descripcion ="Discord es un servicio de mensajería instantánea y chat de voz VolP. En esta plataforma, los usuarios tienen la capacidad de comunicarse por llamadas de voz, videollamadas, mensajes de texto etc",
                TipoSofwareId = aplicacion.Id
               };
                var Chrome = new Software(){
                Id=1,
                Nombre = "Chrome",
                Descripcion ="Navegador web",
                TipoSofwareId = Programacion.Id
               };
               var cat_softwarwe = new CategoriaIncidencia(){
                Id =1,
                Categoria ="Software"
               };
               var cat_Hardware = new CategoriaIncidencia(){
                Id =2,
                Categoria ="Hardware"
               };
               var leve = new GravedadIncidencia(){
                Id =1,
                Gravedad = "Leve" 
               };
                var moderada = new GravedadIncidencia(){
                Id =2,
                Gravedad = "Moderada" 
               };
                var grave = new GravedadIncidencia(){
                Id =3,
                Gravedad = "Grave" 
               };
                modelBuilder.Entity<GravedadIncidencia>().HasData(leve,moderada,grave);
                 modelBuilder.Entity<CategoriaIncidencia>().HasData(cat_softwarwe,cat_Hardware);      
        }

    }
}