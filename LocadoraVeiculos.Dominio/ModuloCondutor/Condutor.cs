using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
	public class Condutor : EntidadeBase
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public int IdEndereco{ get; set; }
		public Endereco Endereco { get; set; }
		public DateTime DataNascimento { get; set; }
		public bool HabilitacaoA { get; set; }
		public bool HabilitacaoB { get; set; }


		public Condutor(string nome, string cpf, int idEndereco, DateTime dataNascimento, bool habilitacaoA, bool habilitacaoB)
        {
            Nome = nome;
            CPF = cpf;
            IdEndereco = idEndereco;
            DataNascimento = dataNascimento;
            HabilitacaoA = habilitacaoA;
            HabilitacaoB = habilitacaoB;
        }

		public override List<string> Validar()
		{
			List<string> erros = [];

			if (Nome.Length < 3)
				erros.Add("O nome deve conter ao menos 3 caracteres");

			return erros;
		}
	}
}
