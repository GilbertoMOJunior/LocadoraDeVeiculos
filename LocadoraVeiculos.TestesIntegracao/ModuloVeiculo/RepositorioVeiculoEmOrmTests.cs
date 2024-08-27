using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.ModuloVeiculo;

namespace LocadoraVeiculos.TestesIntegracao.ModuloVeiculo
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioVeiculoEmOrmTests
    {
        private LocadoraDbContext dbContext;
        private RepositorioVeiculoEmOrm repositorio;
        private RepositorioGrupoDeVeiculosOrm repositorioGrupos;


        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
            dbContext.GruposVeiculos.RemoveRange(dbContext.GruposVeiculos);

            dbContext.SaveChanges();

            repositorio = new RepositorioVeiculoEmOrm(dbContext);
            repositorioGrupos = new RepositorioGrupoDeVeiculosOrm(dbContext);

            BuilderSetup
                .SetCreatePersistenceMethod<Veiculo>(repositorio.Inserir);
            BuilderSetup
                .SetCreatePersistenceMethod<GrupoDeVeiculos>(repositorioGrupos.Inserir);
        }

        [TestMethod]
        public void DeveInserirVeiculo()
        {
            var grupo = Builder<GrupoDeVeiculos>
                .CreateNew()
                .With(g =>  g.Id = 0)
                .Persist();

            var veiculo = Builder<Veiculo>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculoId = grupo.Id)
                .Persist();

            var veiculoSelecionado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoSelecionado);
            Assert.AreEqual(veiculo, veiculoSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_Veiculo()
        {
            var grupo = Builder<GrupoDeVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var veiculo = Builder<Veiculo>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculoId = grupo.Id)
                .Persist();

            veiculo.Modelo = "Novo Modelo";

            repositorio.Editar(veiculo);

            var veiculoSelecionado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoSelecionado);
            Assert.AreEqual(veiculo, veiculoSelecionado);
        }

        [TestMethod]
        public void Deve_Excluir_Veiculo()
        {
            var grupo = Builder<GrupoDeVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var veiculo = Builder<Veiculo>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculoId = grupo.Id)
                .Persist();

            repositorio.Excluir(veiculo);

            var veiculoSelecionado = repositorio.SelecionarPorId(veiculo.Id);

            var veiculos = repositorio.SelecionarTodos();

            Assert.IsNull(veiculoSelecionado);
            Assert.AreEqual(0, veiculos.Count);
        }
    }
}
