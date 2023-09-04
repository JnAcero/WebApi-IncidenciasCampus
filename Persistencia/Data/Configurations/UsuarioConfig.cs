
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u =>u.NombreUsuario)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(u =>u .Password)
            .IsRequired();

            builder.Property(u =>u.FechaCreacion)
            .HasColumnType("date");
            

        }
    }
}