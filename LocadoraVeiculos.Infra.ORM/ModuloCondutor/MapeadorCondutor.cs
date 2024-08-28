using LocadoraVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.NewFolder
{
    public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("DBCondutor");

            builder.Property(c => c.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasColumnType("varchar(25)")
                .IsRequired();
            
            builder.Property(c => c.NumeroCNH)
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithMany()
                .HasForeignKey(c => c.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
