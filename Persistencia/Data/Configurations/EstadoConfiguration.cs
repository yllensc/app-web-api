

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado> //esta interfaz define cómo se van a mapear los datos de x entidad
{
    public void Configure(EntityTypeBuilder<Estado> builder) // Configure es un método de la interfaz. Esta clase es para establecer propiedades, configuración de relaciones, índices, restricciones
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