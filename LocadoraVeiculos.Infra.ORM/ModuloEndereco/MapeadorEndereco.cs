using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloEndereco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloEndereco
{
	public class MapeadorEndereco : IEntityTypeConfiguration<Endereco>
	{
		public void Configure(EntityTypeBuilder<Endereco> builder)
		{
			builder.ToTable("TBEndereco");

			builder.Property(e => e.Id)
				.HasColumnType("int")
				.ValueGeneratedOnAdd()
				.IsRequired();
			
			builder.Property(e => e.Estado)
				.HasColumnType("int")
				.IsRequired();
			
			builder.Property(e => e.Cidade)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(e => e.Bairro)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(e => e.Rua)
				.HasColumnType("varchar(50)")
				.IsRequired();
			
			builder.Property(e => e.Numero)
				.HasColumnType("varchar(20)")
				.IsRequired();
		}
	}
}
