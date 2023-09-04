
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class IncidenciaSoftwareConfig : IEntityTypeConfiguration<IncidenciaSoftware>
    {
        public void Configure(EntityTypeBuilder<IncidenciaSoftware> builder)
        {
            builder.HasKey(x => new{x.SoftwareId,x.IncidenciaId});
            builder.Property(x =>x.Descripcion).HasColumnType("varchar(2000)")
            .IsRequired();
        }
    }
}