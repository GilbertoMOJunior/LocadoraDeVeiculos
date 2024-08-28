using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloCondutor
{
    [TestClass]
    [TestCategory("Unidade")]
    public class CondutorTestes
    {
        [TestMethod]
        public void DeveCriarInstanciaValida()
        {
            var endereco = new Endereco(EstadoEnum.Santa_Catarina, "Lages", "Coral", "Dom Pedro II", "370");

            var condutor = new Condutor("Nome", "08689966960", endereco, DateTime.MinValue, "098765432");

            var erros = condutor.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void DeveCriarInstanciaInvalida()
        {
            var endereco = new Endereco(EstadoEnum.Santa_Catarina, "", "", "", "");

            var condutor = new Condutor("", "", endereco, DateTime.Today, "");

            var erros = condutor.Validar();

            List<string> errosEsperados =
            [
                "O nome deve conter ao menos 3 caracteres",

                "CPF invalido!",

                "O condutor deve ser maior de idade",

                "O condutor deve possuir habilitação"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
