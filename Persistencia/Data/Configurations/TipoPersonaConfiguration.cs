using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class TipoPersonaConfiguration: IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("TipoPersona");
        builder.Property(tp => tp.Descripcion)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(tp => tp.Descripcion)
            .IsUnique();
    }
}