using LocadoraVeiculos.Dominio.ModuloEndereco;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloEndereco
{
	public class RepositorioEnderecoEmOrm : RepositorioBaseEmOrm<Endereco>, IRepositorioEndereco
	{
		public RepositorioEnderecoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<Endereco> ObterRegistros()
		{
			return dbContext.Enderecos;
		}

		public List<Endereco> Filtrar(Func<Endereco, bool> predicate)
		{
			throw new NotImplementedException();
		}
	}
}
