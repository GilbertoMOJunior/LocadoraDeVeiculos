using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloEndereco;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.ModuloEndereco;

namespace LocadoraVeiculos.TestesIntegracao.ModuloGrupoVeiculos
{
	[TestClass]
	[TestCategory("Integracao")]
	public class RepositorioClienteOrmTestes
	{
		private LocadoraDbContext dbContext;
		private RepositorioClienteEmOrm repositorio;
		private RepositorioEnderecoEmOrm repositorioEndereco;

		[TestInitialize]
		public void Inicializar()
		{
			dbContext = new LocadoraDbContext();

			dbContext.Clientes.RemoveRange(dbContext.Clientes);

			dbContext.Enderecos.RemoveRange(dbContext.Enderecos);

			dbContext.SaveChanges();

			repositorio = new RepositorioClienteEmOrm(dbContext);
			repositorioEndereco = new RepositorioEnderecoEmOrm(dbContext);

			BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorio.Inserir);
			BuilderSetup.SetCreatePersistenceMethod<Endereco>(repositorioEndereco.Inserir);
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

			var clienteSelcionado = repositorio.SelecionarPorId(cliente.Id);

			Assert.IsNotNull(clienteSelcionado);
			Assert.AreEqual(cliente, clienteSelcionado);
		}

		[TestMethod]
		public void DeveEditarCliente()
		{
			//Arrange
            var endereco = Builder<Endereco>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();
			
            var cliente = Builder<Cliente>
				.CreateNew()
				.With(x => x.Id = 0)
                .With(c => c.EnderecoId = endereco.Id)
				.Persist();

			cliente.Nome = "Teste de Edicao";
			//Action
			repositorio.Editar(cliente);

			//Assert
			var clienteSelcionado = repositorio.SelecionarPorId(cliente.Id);

			Assert.IsNotNull(clienteSelcionado);
			Assert.AreEqual(cliente, clienteSelcionado);
		}

		[TestMethod]
		public void DeveExcluirCliente()
		{
            //Arrange
            var endereco = Builder<Endereco>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();


            var cliente = Builder<Cliente>
				.CreateNew()
				.With(g => g.Id = 0)
                .With(c => c.EnderecoId = endereco.Id)
				.Persist();

			//Action
			repositorio.Excluir(cliente);

			//Assert
			Assert.IsNull(repositorio.SelecionarPorId(cliente.Id));
			Assert.AreEqual(0, repositorio.SelecionarTodos().Count);
		}
	}
}
