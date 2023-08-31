using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Genero");
        builder.Property(g => g.NombreGenero)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(g => g.NombreGenero)
            .IsUnique();
    
    }
}
