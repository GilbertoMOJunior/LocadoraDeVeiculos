using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloTaxa
{
    public class MapeadorTaxa : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");

            builder.Property(t => t.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(t => t.TipoCobranca)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(t => t.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
