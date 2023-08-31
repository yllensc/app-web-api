using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MatriculaConfigurationpublic : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.HasKey(m => new { m.IdPersonaFK, m.IdSalonFK }); // Definir clave primaria compuesta

        builder.HasOne(m => m.Persona)
            .WithMany()
            .HasForeignKey(m => m.IdPersonaFK); 

        builder.HasOne(m => m.Salones)
            .WithMany()
            .HasForeignKey(m => m.IdSalonFK); 
    }
}
}