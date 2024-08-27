using LocadoraVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloVeiculo
{
    public class MapeadorVeiculo  : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBveiculo");

            builder.Property(v => v.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(v => v.Modelo)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(v => v.Marca)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(v => v.Ano)
                .HasColumnType("varchar(10)")
                .IsRequired();
            
            builder.Property(v => v.TipoCombustivel)
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(v => v.GrupoVeiculoId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(v => v.Grupo)
                .WithMany(g => g.Veiculos)
                .HasForeignKey(v => v.GrupoVeiculoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
