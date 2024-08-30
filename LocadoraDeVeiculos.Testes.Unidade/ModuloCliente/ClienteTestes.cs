using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloCliente
{
	[TestClass]
	[TestCategory("Unidade")]
	public class ClienteTestes
	{
		[TestMethod]
		public void DeveCriarInstanciaValida()
		{
			var endereco = new Endereco(EstadoEnum.Santa_Catarina,"Lages","Coral","Dom Pedro II", "370");

			var cliente = new Cliente("Nome", "email", "telefone", endereco, TipoCadastroClienteEnum.CPF, "08689966960");
			
			var erros = cliente.Validar();

			Assert.AreEqual(0, erros.Count);
		}

		[TestMethod]
		public void DeveCriarInstanciaInvalida()
		{
			var endereco = new Endereco(EstadoEnum.Santa_Catarina, "", "", "", "");

			var cliente = new Cliente("", "", "", endereco, 0, "");

			var erros = cliente.Validar();

			List<string> errosEsperados =
			[
				"O campo nome é obrigatório",

				"O campo email é obrigatório",

				"O campo telefone é obrigatório"
			];

			Assert.AreEqual(errosEsperados.Count, erros.Count);
			CollectionAssert.AreEqual(errosEsperados, erros);
		}
	}
}
