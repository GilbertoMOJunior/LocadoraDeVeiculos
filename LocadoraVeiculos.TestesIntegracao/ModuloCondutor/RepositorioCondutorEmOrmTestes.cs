using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloEndereco;
using LocadoraVeiculos.Infra.ORM.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.ModuloEndereco;
using LocadoraVeiculos.Infra.ORM.NewFolder;

namespace LocadoraVeiculos.TestesIntegracao.ModuloCondutor
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioCondutorEmOrmTestes
    {
        private LocadoraDbContext dbContext;
        private RepositorioCondutorEmOrm repositorio;
        private RepositorioEnderecoEmOrm repositorioEndereco;
        private RepositorioClienteEmOrm repositorioCliente;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.Condutores.RemoveRange(dbContext.Condutores);
            dbContext.Clientes.RemoveRange(dbContext.Clientes);
            dbContext.Enderecos.RemoveRange(dbContext.Enderecos);

            dbContext.SaveChanges();

            repositorio = new RepositorioCondutorEmOrm(dbContext);
            repositorioEndereco = new RepositorioEnderecoEmOrm(dbContext);
            repositorioCliente = new RepositorioClienteEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorio.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Endereco>(repositorioEndereco.Inserir);
        }

        [TestMethod]
        public void DeveInserirCondutor()
        {
            //Arrange
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Build();

            //Action
            repositorio.Inserir(condutor);

            //Assert
            var condutorSelecionado = repositorio.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorSelecionado);
            Assert.AreEqual(condutor, condutorSelecionado);
        }
        [TestMethod]                      
        public void DeveEditarCondutor()
        {
            //Arrange
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Build();

            condutor.Nome = "Teste";

            //Action
            repositorio.Editar(condutor);

            //Assert

            var condutorSelecionado = repositorio.SelecionarPorId(condutor.Id);

            Assert.AreEqual(condutor, condutorSelecionado);
            Assert.IsNotNull(condutorSelecionado);
        }
        [TestMethod]                      
        public void DeveExcluirCondutor()
        {
            //Arrange
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Build();

            //Action
            repositorio.Excluir(condutor);

            //Assert
            Assert.IsNull(repositorio.SelecionarPorId(condutor.Id));
            Assert.AreEqual(0 , repositorio.SelecionarTodos().Count);
        }
    }
}
