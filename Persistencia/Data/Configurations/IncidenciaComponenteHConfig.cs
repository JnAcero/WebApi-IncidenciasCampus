
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class IncidenciaComponenteHConfig : IEntityTypeConfiguration<IncidenciaComponenteH>
    {
        public void Configure(EntityTypeBuilder<IncidenciaComponenteH> builder)
        {
            builder.HasKey(x => new{x.ComponenteHardwareId,x.IncidenciaId});
            builder.Property(x => x.Descripcion).HasColumnType("varchar(2000)")
            .IsRequired();
        }
    }
}