using LocadoraVeiculos.Dominio.ModuloPlanos;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloPlanoCobranca
{
	[TestClass]
	[TestCategory("Unidade")]
	public class PlanosTests
	{
		[TestMethod]
		public void DeveCriarInstanciaValida()
		{
			var planoCobranca = new PlanoCobranca
			(
				1,
				100.0m,
				1.0m,
				200.0m,
				80.0m,
				2.0m,
				150.0m
			);

			var erros = planoCobranca.Validar();

			Assert.AreEqual(0, erros.Count);
		}

		[TestMethod]
		public void DeveCriarInstanciaInvalida()
		{
			var planoCobranca = new PlanoCobranca
			(
				0,
				0.0m,
				0.0m,
				0.0m,
				0.0m,
				0.0m,
				0.0m
			);

			var erros = planoCobranca.Validar();

			List<string> errosEsperado =
			[
					"O grupo de veiculo é obrigatório"
			];

			Assert.AreEqual(errosEsperado.Count, erros.Count);
			CollectionAssert.AreEqual(errosEsperado, erros);
		}
	}
}
