using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloCliente
{
	public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
	{
		public RepositorioClienteEmOrm(LocadoraDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<Cliente> ObterRegistros()
		{
			return dbContext.Clientes;
		}

		public List<Cliente> Filtrar(Func<Cliente, bool> predicate)
		{
			throw new NotImplementedException();
		}
	}
}
