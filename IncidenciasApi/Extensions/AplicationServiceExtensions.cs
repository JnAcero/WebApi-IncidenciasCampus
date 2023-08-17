using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

namespace IncidenciasApi.Extensions
{
    public static class AplicationServiceExtensions
    {
         public static void ConfigCores(this IServiceCollection services) =>
             services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy", builder =>
                 builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
             });
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}