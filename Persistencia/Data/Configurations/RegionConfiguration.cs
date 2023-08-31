using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class RegionConfiguration: IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Region");
        builder.Property(r => r.NombreRegion)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasOne(r => r.Estado)
            .WithMany(r =>r.Regiones)
            .HasForeignKey(r => r.IdEstadoFK);
    }
}
