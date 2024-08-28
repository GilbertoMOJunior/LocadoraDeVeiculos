using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloCliente
{
	public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.ToTable("TBCliente");

			builder.Property(c => c.Id)
				.HasColumnType("int")
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(c => c.Email)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(c => c.Telefone)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(c => c.TipoCadastro)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(c => c.NumeroDocumento)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(c => c.EnderecoId)
				.HasColumnType("int")
				.IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithMany()  
                .HasForeignKey(c => c.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
	}
}
