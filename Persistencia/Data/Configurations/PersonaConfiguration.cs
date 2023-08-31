using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class PersonaConfiguration: IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");
        builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(70);
        builder.Property(p => p.Apellido)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasOne(p => p.Genero)
            .WithMany(p =>p.Personas)
            .HasForeignKey(p => p.IdGeneroFK);
        builder.HasOne(p => p.TipoPersona)
            .WithMany(p =>p.Personas)
            .HasForeignKey(p => p.TipoPersonaIdFK);
        builder.HasOne(p => p.Region)
            .WithMany(p =>p.Personas)
            .HasForeignKey(p => p.IdRegionFK);
        

    }
}
