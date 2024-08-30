using FizzWare.NBuilder;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;

namespace LocadoraVeiculos.TestesIntegracao.ModuloTaxa
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioTaxaEmOrmTests
    {
        private LocadoraDbContext dbContext;
        private RepositorioTaxaEmOrm repositorio;


        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.Taxas.RemoveRange(dbContext.Taxas);

            dbContext.SaveChanges();

            repositorio = new RepositorioTaxaEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Taxa>(repositorio.Inserir);
        }

        [TestMethod]
        public void DeveInserirTaxa()
        {
            var taxa = Builder<Taxa>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();
            
            var taxaSelecionada= repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaSelecionada);
            Assert.AreEqual(taxa, taxaSelecionada);
        }

        [TestMethod]
        public void Deve_Editar_Taxa()
        {
            var taxa = Builder<Taxa>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            taxa.Nome = "Novo Modelo";

            repositorio.Editar(taxa);

            var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaSelecionada);
            Assert.AreEqual(taxa, taxaSelecionada);
        }

        [TestMethod]
        public void Deve_Excluir_Taxa()
        {
            var taxa = Builder<Taxa>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            repositorio.Excluir(taxa);

            var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

            var taxas = repositorio.SelecionarTodos();

            Assert.IsNull(taxaSelecionada);
            Assert.AreEqual(0, taxas.Count);
        }
    }
}
