using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloGrupoDeVeiculos;

public class MapeadorGrupoDeVeiculos : IEntityTypeConfiguration<GrupoDeVeiculos>
{
    public void Configure(EntityTypeBuilder<GrupoDeVeiculos> builder)
    {
        builder.ToTable("TBGrupoVeiculos");

        builder.Property(g => g.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(g => g.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}