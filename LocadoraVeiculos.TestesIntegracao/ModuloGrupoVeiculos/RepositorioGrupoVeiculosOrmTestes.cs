using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloGrupoDeVeiculos;

namespace LocadoraVeiculos.TestesIntegracao.ModuloGrupoVeiculos
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioGrupoVeiculosOrmTestes
    {
        private LocadoraDbContext dbContext;
        private RepositorioGrupoDeVeiculosOrm repositorio;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.Veiculos.RemoveRange(dbContext.Veiculos);

            dbContext.GruposVeiculos.RemoveRange(dbContext.GruposVeiculos);

            dbContext.SaveChanges();

            repositorio = new RepositorioGrupoDeVeiculosOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod
                <GrupoDeVeiculos>(repositorio.Inserir);
        }

        [TestMethod]
        public void DeveInserirGrupoVeiculos()
        {
            var grupo = new GrupoDeVeiculos("SUV");

            repositorio.Inserir(grupo);

            var grupoSelcionado = repositorio
                .SelecionarPorId(grupo.Id);
            
            Assert.IsNotNull(grupoSelcionado);
            Assert.AreEqual(grupo, grupoSelcionado);
        }

        [TestMethod]
        public void DeveEditarGrupoVeiculos()
        {
            //Arrange
            var grupo = Builder<GrupoDeVeiculos>
                .CreateNew()
                .With(x => x.Id = 0)
                .Persist();

            grupo.Nome = "Teste de Edicao";
            //Action
            repositorio.Editar(grupo);

            //Assert
            var grupoSelcionado = repositorio
                .SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoSelcionado);
            Assert.AreEqual(grupo, grupoSelcionado);
        }

        [TestMethod]
        public void DeveExcluirGrupoVeiculos()
        {
            //Arrange
            var grupo = Builder<GrupoDeVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            //Action
            repositorio.Excluir(grupo);
            
            //Assert
            
            Assert.IsNull(repositorio.SelecionarPorId(grupo.Id));
            Assert.AreEqual(0, repositorio.SelecionarTodos().Count);
        }
    }
}
