using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
	public class Cliente : EntidadeBase
	{
		public Cliente(string nome, string email, string telefone, Endereco endereco, TipoCadastroClienteEnum tipoCadastro, string numeroDocumento)
		{
			Nome = nome;
			Email = email;
			Telefone = telefone;
			Endereco = endereco;

			TipoCadastro = tipoCadastro;
			NumeroDocumento = numeroDocumento;
		}

		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public int EnderecoId { get; set; }
		public Endereco Endereco{ get; set; }

		//public int CondutorId { get; set; }
		//public Condutor Condutor { get; set; }

		public TipoCadastroClienteEnum TipoCadastro { get; set; }
		public string NumeroDocumento { get; set; }

		public Cliente() { }

		public override List<string> Validar()
		{
			List<string> erros = [];

			if (Nome.Length < 3)
				erros.Add("O campo nome é obrigatório");
			
			if (Email.Length < 3)
				erros.Add("O campo email é obrigatório");
			
			if (Telefone.Length < 3)
				erros.Add("O campo telefone é obrigatório");

			return erros;
		}
	}
}
