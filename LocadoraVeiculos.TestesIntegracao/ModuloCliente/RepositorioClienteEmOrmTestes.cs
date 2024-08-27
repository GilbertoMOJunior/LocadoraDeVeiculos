using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloEndereco;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloCliente;

namespace LocadoraVeiculos.TestesIntegracao.ModuloGrupoVeiculos
{
	[TestClass]
	[TestCategory("Integracao")]
	public class RepositorioClienteOrmTestes
	{
		private LocadoraDbContext dbContext;
		private RepositorioClienteEmOrm repositorio;

		[TestInitialize]
		public void Inicializar()
		{
			dbContext = new LocadoraDbContext();

			dbContext.Clientes.RemoveRange(dbContext.Clientes);

			dbContext.Enderecos.RemoveRange(dbContext.Enderecos);

			dbContext.SaveChanges();

			repositorio = new RepositorioClienteEmOrm(dbContext);

			BuilderSetup.SetCreatePersistenceMethod
				<Cliente>(repositorio.Inserir);
		}

		[TestMethod]
		public void DeveInserirCliente()
		{
			var endereco = Builder<Endereco>
				.CreateNew()
				.With(e => e.Id = 0)
				.Persist();

			var cliente = Builder<Cliente>
			.CreateNew()
				.With(c => c.Id = 0)
				.With(c => c.EnderecoId = endereco.Id)
				.Persist();

			repositorio.Inserir(cliente);

			var clienteSelcionado = repositorio
				.SelecionarPorId(cliente.Id);

			Assert.IsNotNull(clienteSelcionado);
			Assert.AreEqual(cliente, clienteSelcionado);
		}

		[TestMethod]
		public void DeveEditarCliente()
		{
			//Arrange
			var cliente = Builder<Cliente>
				.CreateNew()
				.With(x => x.Id = 0)
				.Persist();

			cliente.Nome = "Teste de Edicao";
			//Action
			repositorio.Editar(cliente);

			//Assert
			var clienteSelcionado = repositorio
				.SelecionarPorId(cliente.Id);

			Assert.IsNotNull(clienteSelcionado);
			Assert.AreEqual(cliente, clienteSelcionado);
		}

		[TestMethod]
		public void DeveExcluirCliente()
		{
			//Arrange
			var cliente = Builder<Cliente>
				.CreateNew()
				.With(g => g.Id = 0)
				.Persist();

			//Action
			repositorio.Excluir(cliente);

			//Assert

			Assert.IsNull(repositorio.SelecionarPorId(cliente.Id));
			Assert.AreEqual(0, repositorio.SelecionarTodos().Count);
		}
	}
}
