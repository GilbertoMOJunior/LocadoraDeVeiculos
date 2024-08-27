using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloPlanos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloPlanos
{
	public class MapeadorPlanos : IEntityTypeConfiguration<PlanoCobranca>
	{
		public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
		{
			builder.ToTable("TBPlanos");

			builder.Property(p => p.Id)
				.HasColumnType("int")
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(p => p.PrecoDiarioPlanoDiario)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			
			builder.Property(p => p.PrecoDiarioPlanoControlado)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			
			builder.Property(p => p.PrecoDiarioPlanoLivre)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			
			builder.Property(p => p.PrecoKmPlanoDiario)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			
			builder.Property(p => p.PrecoKmPlanoControlado)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			
			builder.Property(p => p.KmDisponiveisPlanoControlado)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			
			builder.Property(p => p.GrupoVeiculosId)
				.HasColumnType("int")
				.IsRequired();

			builder.HasOne(p => p.GrupoVeiculos)
				.WithMany()
				.HasForeignKey(p => p.GrupoVeiculosId)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
