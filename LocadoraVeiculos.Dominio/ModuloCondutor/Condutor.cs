using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
	public class Condutor : EntidadeBase
	{
		public string Nome { get; set; }
		public string DataNascimento { get; set; }
		public TipoHabilitacaoEnum Habilitacao { get; set; }


		public override List<string> Validar()
		{
			List<string> erros = [];

			if (Nome.Length < 3)
				erros.Add("O nome de ve conter ao menos 3 caracteres");

			return erros;
		}
	}
}
