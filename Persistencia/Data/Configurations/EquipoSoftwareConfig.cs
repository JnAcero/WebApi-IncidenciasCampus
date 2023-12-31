
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EquipoSoftwareConfig : IEntityTypeConfiguration<EquipoSoftware>
    {
        public void Configure(EntityTypeBuilder<EquipoSoftware> builder)
        {
           builder.HasKey(e=>new{e.EquipoId,e.SoftwareId});
        }
    }
}