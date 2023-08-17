using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TrainerConfig : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(x => x.FechaNacimineto).HasColumnType("date")
            .IsRequired();
            builder.Property(x => x.NumDocumento).HasMaxLength(50)
            .IsRequired();
            builder.Property(x => x.Nombres).HasMaxLength(50)
            .IsRequired();
             builder.Property(x => x.Apellidos).HasMaxLength(50)
            .IsRequired();
            builder.Property(x => x.Genero).HasMaxLength(50)
            .IsRequired();
            builder.Property(x => x.Direccion).HasMaxLength(100)
            .IsRequired();

        }
    }
}