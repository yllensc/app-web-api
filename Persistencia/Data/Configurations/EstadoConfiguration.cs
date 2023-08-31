

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estado");
        builder.Property(e => e.NombreEstado)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(e => e.NombreEstado)
            .IsUnique();
        builder.HasOne(e => e.Pais)
            .WithMany(e =>e.Estados)
            .HasForeignKey(e => e.IdPaisFK);
    }
}