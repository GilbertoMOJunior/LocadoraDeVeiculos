using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloCliente
{
	[TestClass]
	[TestCategory("Unidade")]
	public class EnderecoTestes
	{
		[TestMethod]
		public void DeveCriarInstanciaValida()
		{
			var endereco = new Endereco(EstadoEnum.Santa_Catarina, "Lages", "Coral", "Dom Pedro II", "370");

			var erros = endereco.Validar();

			Assert.AreEqual(0, erros.Count);
		}

		[TestMethod]
		public void DeveCriarInstanciaInvalida()
		{
			var endereco = new Endereco(0, "", "", "", "");

			var erros = endereco.Validar();

			List<string> errosEsperados =
			[
				"O campo cidade é obrigatório",

				"O campo bairro é obrigatório",

				"O campo rua é obrigatório",

				"O campo numero é obrigatório"
			];

			Assert.AreEqual(errosEsperados.Count, erros.Count);
			CollectionAssert.AreEqual(errosEsperados, erros);
		}
	}
}