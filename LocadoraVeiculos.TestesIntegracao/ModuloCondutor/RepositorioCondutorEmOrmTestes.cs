using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloEndereco;
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

            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorio.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Endereco>(repositorioEndereco.Inserir);
        }

        [TestMethod]
        public void DeveInserirCondutor()
        {
            //Arrange
            var endereco = Builder<Endereco>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.EnderecoId = endereco.Id)
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
            var endereco = Builder<Endereco>
                .CreateNew()
                .With(e => e.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.EnderecoId = endereco.Id)
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
            //Action
            //Assert
            }
    }
}
