using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Pais");
        builder.Property(p => p.NombrePais)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(p => p.NombrePais)
            .IsUnique();
    }
    
    
}