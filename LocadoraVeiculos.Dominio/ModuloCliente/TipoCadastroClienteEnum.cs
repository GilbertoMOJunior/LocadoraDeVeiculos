using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
	public enum TipoCadastroClienteEnum
	{
		[Display(Name = "Pessoa Física")] CPF,
		[Display(Name = "Pessoa Jurídica")] CNPJ
	}
}
