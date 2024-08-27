using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.ModuloEndereco;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloEndereco;

namespace LocadoraVeiculos.TestesIntegracao.ModuloGrupoVeiculos
{
	[TestClass]
	[TestCategory("Integracao")]
	public class RepositorioEnderecoOrmTestes
	{
		private LocadoraDbContext dbContext;
		private RepositorioEnderecoEmOrm repositorio;

		[TestInitialize]
		public void Inicializar()
		{
			dbContext = new LocadoraDbContext();

			dbContext.Enderecos.RemoveRange(dbContext.Enderecos);

			dbContext.SaveChanges();

			repositorio = new RepositorioEnderecoEmOrm(dbContext);

			BuilderSetup.SetCreatePersistenceMethod
				<Endereco>(repositorio.Inserir);
		}

		[TestMethod]
		public void DeveInserirEndereco()
		{
			var endereco = new Endereco();

			repositorio.Inserir(endereco);

			var enderecoSelcionado = repositorio
				.SelecionarPorId(endereco.Id);

			Assert.IsNotNull(enderecoSelcionado);
			Assert.AreEqual(endereco, enderecoSelcionado);
		}

		[TestMethod]
		public void DeveEditarEndereco()
		{
			//Arrange
			var endereco = Builder<Endereco>
				.CreateNew()
				.With(x => x.Id = 0)
				.Persist();

			endereco.Cidade = "Teste de Edicao";
			//Action
			repositorio.Editar(endereco);

			//Assert
			var enderecoSelcionado = repositorio
				.SelecionarPorId(endereco.Id);

			Assert.IsNotNull(enderecoSelcionado);
			Assert.AreEqual(endereco, enderecoSelcionado);
		}

		[TestMethod]
		public void DeveExcluirEndereco()
		{
			//Arrange
			var endereco = Builder<Endereco>
				.CreateNew()
				.With(e => e.Id = 0)
				.Persist();

			//Action
			repositorio.Excluir(endereco);

			//Assert

			Assert.IsNull(repositorio.SelecionarPorId(endereco.Id));
			Assert.AreEqual(0, repositorio.SelecionarTodos().Count);
		}
	}
}
