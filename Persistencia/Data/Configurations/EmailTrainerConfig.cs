
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EmailTrainerConfig : IEntityTypeConfiguration<EmailTrainer>
    {
        public void Configure(EntityTypeBuilder<EmailTrainer> builder)
        {
            builder.HasKey(x =>new{x.TrainerId,x.TipoEmailId});
            builder.Property(x =>x.Email).HasMaxLength(200)
            .IsRequired();
        }
    }
}