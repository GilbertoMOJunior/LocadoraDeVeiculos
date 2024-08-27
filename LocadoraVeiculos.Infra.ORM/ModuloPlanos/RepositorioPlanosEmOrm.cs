using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloPlanos;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloPlanos
{
	public class RepositorioPlanosEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanos
	{
		public RepositorioPlanosEmOrm(LocadoraDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<PlanoCobranca> ObterRegistros()
		{
			return dbContext.Planos;
		}

		public override PlanoCobranca? SelecionarPorId(int id)
		{
			return ObterRegistros()
				.Include(p => p.GrupoVeiculos)
				.FirstOrDefault(p => p.Id == id);
		}

		public override List<PlanoCobranca> SelecionarTodos()
		{
			return ObterRegistros()
				.Include(p => p.GrupoVeiculos)
				.AsNoTracking()
				.ToList();
		}

		public List<PlanoCobranca> Filtrar(Func<PlanoCobranca, bool> predicate)
		{
			throw new NotImplementedException();
		}
	}
}
