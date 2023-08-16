using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TelefonoTrainerConfig : IEntityTypeConfiguration<TelefonoTrainer>
    {
        public void Configure(EntityTypeBuilder<TelefonoTrainer> builder)
        {
            builder.HasKey(x =>new{x.TipoTelefonoId,x.TrainerId});
            builder.Property(x =>x.NumeroTelefono).HasMaxLength(25)
            .IsRequired();

        }
    }
}