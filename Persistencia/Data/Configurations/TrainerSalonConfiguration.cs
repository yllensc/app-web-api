using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class TrainerSalonConfiguration : IEntityTypeConfiguration<TrainerSalon>
{
    public void Configure(EntityTypeBuilder<TrainerSalon> builder)
    {
        builder.HasKey(ts => new { ts.IdPersonaFK, ts.IdSalonFK }); // Definir clave primaria compuesta

        builder.HasOne(ts => ts.Persona)
            .WithMany()
            .HasForeignKey(ts => ts.IdPersonaFK); 

        builder.HasOne(ts => ts.Salones)
            .WithMany()
            .HasForeignKey(ts => ts.IdSalonFK); 
    }
}
