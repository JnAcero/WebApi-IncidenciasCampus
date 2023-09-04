
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class IncidenciaConfig : IEntityTypeConfiguration<Incidencia>
    {
        public void Configure(EntityTypeBuilder<Incidencia> builder)
        {
            builder.Property(x => x.EstadoIncidencia).HasColumnType("varchar(150)");
             builder.Property(x => x.Descripcion).HasColumnType("varchar(280)")
             .IsRequired();
            
            builder.Property(x =>x.FechaReporte).HasColumnType("date")
            .IsRequired();
        }
    }
}