
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TrainerContactoConfig : IEntityTypeConfiguration<TrainerContacto>
    {
        public void Configure(EntityTypeBuilder<TrainerContacto> builder)
        {
            builder.HasKey(x =>new{x.TrainerId,x.ContactoId});
           
        }
    }
}