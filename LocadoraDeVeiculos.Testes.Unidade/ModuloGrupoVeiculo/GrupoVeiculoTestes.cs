using LocadoraVeiculos.Dominio.GrupoDeVeiculos;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloGrupoVeiculo
{
    [TestClass]
    [TestCategory("Unidade")]
    public class GrupoVeiculoTestes
    {
        [TestMethod]
        public void DeveCriarInstancia_Valida()
        {
            var grupo = new GrupoDeVeiculos("SUV");

            var erros = grupo.Validar();

            Assert.AreEqual(0, erros.Count);
        }
        [TestMethod]
        public void DeveCriarInstancia_Invalida()
        {
            var grupo = new GrupoDeVeiculos("");

            var erros = grupo.Validar();

            List<string> errosEsperados = ["O nome é obrigatório"];

            Assert.AreNotEqual(0, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
