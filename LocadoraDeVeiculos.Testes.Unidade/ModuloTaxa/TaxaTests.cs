using LocadoraVeiculos.Dominio.ModuloTaxa;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloTaxa
{
    [TestClass]
    [TestCategory("Unidade")]

    public class TaxaTests
    {
        

        [TestMethod]
        public void DeveCriarInstaciaValida()
        {
            var taxa = new Taxa(
                "Nome",
                TipoCobrancaEnum.Fixo,
                10.0m
            );

            var erros = taxa.Validar();

            Assert.AreEqual(0, erros.Count);
        }
        [TestMethod]
        public void DeveCriarInstaciaInvalida()
        {
            var taxa = new Taxa(
                "",
                0,
                0.0m);

            var erros = taxa.Validar();

            List<string> errosEsperados =
            [
                "O valor deve ser no minimo 1",
                "O Nome deve ter mais de 3 caracteres"
            ];

            Assert.AreEqual(erros.Count, errosEsperados.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
