using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloVeiculo
{
    [TestClass]
    [TestCategory("Unidade")]
    public class VeiculoTests
    {
        [TestMethod]
        public void DeveCriarInstanciaValida()
        {
            var grupo = new GrupoDeVeiculos("SUV");

            var veiculo = new Veiculo
            (
                "Modelo x",
                "Marca y",
                TipoCombustivelEnum.Gasolina,
                "2000",
                1
            );
            var erros = veiculo.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void DeveCriarInstanciaInvaliada()
        {
            var veiculo = new Veiculo
            (
                "",
                "",
                TipoCombustivelEnum.Gasolina,
                "",
                0
            );

            var erros = veiculo.Validar();

            List<string> errosEsperados = 
            [
                "O Modelo é obrigatorio",
                "A Marca é obrigatoria",
                "O Grupo de Veiculos é obrigatorio"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
