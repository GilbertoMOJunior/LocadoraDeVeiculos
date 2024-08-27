using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanos;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.ModuloPlanos;

namespace LocadoraVeiculos.TestesIntegracao.ModuloPlanos
{
	[TestClass]
	[TestCategory("Integracao")]
	public class RepositorioPlanosEmOrmTests
	{
		private LocadoraDbContext dbContext;
		private RepositorioPlanosEmOrm repositorio;
		private RepositorioGrupoDeVeiculosOrm repositorioGrupo;

		[TestInitialize]
		public void Inicializar()
		{
			dbContext =  new LocadoraDbContext();

			dbContext.Planos.RemoveRange(dbContext.Planos);
			dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
			dbContext.GruposVeiculos.RemoveRange(dbContext.GruposVeiculos);

			repositorio = new RepositorioPlanosEmOrm(dbContext);
			repositorioGrupo = new RepositorioGrupoDeVeiculosOrm(dbContext);

			BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorio.Inserir);
			BuilderSetup.SetCreatePersistenceMethod<GrupoDeVeiculos>(repositorioGrupo.Inserir);
		}

		[TestMethod]
		public void DeveInserirPlano()
		{
			var grupo = Builder<GrupoDeVeiculos>
				.CreateNew()
				.With(g => g.Id = 0)
				.Persist();

			var planoCobranca = Builder<PlanoCobranca>
				.CreateNew()
				.With(p => p.Id = 0)
				.With(p => p.GrupoVeiculosId = grupo.Id)
				.Build();

			repositorio.Inserir(planoCobranca);

			var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

			Assert.IsNotNull(planoCobrancaSelecionado);
			Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
		}

		[TestMethod]
		public void Deve_Editar_PlanoCobranca()
		{
			var grupo = Builder<GrupoDeVeiculos>
				.CreateNew()
				.With(g => g.Id = 0)
				.Persist();

			var planoCobranca = Builder<PlanoCobranca>
				.CreateNew()
				.With(p => p.Id = 0)
				.With(p => p.GrupoVeiculosId = grupo.Id)
				.Persist();

			planoCobranca.PrecoDiarioPlanoDiario = 200.0m;

			repositorio.Editar(planoCobranca);

			var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

			Assert.IsNotNull(planoCobrancaSelecionado);
			Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
		}

		[TestMethod]
		public void Deve_Excluir_PlanoCobranca()
		{
			var grupo = Builder<GrupoDeVeiculos>
				.CreateNew()
				.With(g => g.Id = 0)
				.Persist();

			var planoCobranca = Builder<PlanoCobranca>
				.CreateNew()
				.With(p => p.Id = 0)
				.With(p => p.GrupoVeiculosId = grupo.Id)
				.Persist();

			repositorio.Excluir(planoCobranca);

			var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

			var planosCobranca = repositorio.SelecionarTodos();

			Assert.IsNull(planoCobrancaSelecionado);
			Assert.AreEqual(0, planosCobranca.Count);
		}
	}
}
