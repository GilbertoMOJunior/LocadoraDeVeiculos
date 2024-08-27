using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloEndereco
{
	public class Endereco : EntidadeBase
	{
		public string Cidade { get; set; }
		public EstadoEnum Estado { get; set; }
		public string Bairro { get; set; }
		public string Rua { get; set; }
		public string Numero { get; set; }

		public Endereco(EstadoEnum estado, string cidade, string bairro, string rua, string numero)
		{
			Estado = estado;
			Cidade = cidade;
			Bairro = bairro;
			Rua = rua;
			Numero = numero;
		}

		public override List<string> Validar()
		{
			List<string> erros = [];

			if (Cidade.Length < 1)
				erros.Add("O campo cidade é obrigatório");
			
			if (Bairro.Length < 1)
				erros.Add("O campo bairro é obrigatório");
			
			if (Rua.Length < 1)
				erros.Add("O campo rua é obrigatório");
			
			if (Numero.Length < 1)
				erros.Add("O campo numero é obrigatório");

			return erros;
		}
	}
}
