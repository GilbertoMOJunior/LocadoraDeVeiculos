using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
    
	public class Condutor : EntidadeBase
	{
        public int ClienteId { get; set; }
        public Cliente? Cliente{ get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
        public string NumeroCNH { get; set; }

		public Condutor(string nome, string cpf, DateTime dataNascimento, string numeroCnh, int clienteId)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            NumeroCNH = numeroCnh;
            ClienteId = clienteId;
        }

        public Condutor()
        {
        }

		public override List<string> Validar()
		{
			List<string> erros = [];

			if (Nome.Length < 3)
				erros.Add("O nome deve conter ao menos 3 caracteres");

            if (!ValidarCPF(CPF))
                erros.Add("CPF invalido!");

            if (MenorDeIdade(DataNascimento))
                erros.Add("O condutor deve ser maior de idade");

            if (NumeroCNH.Length < 9)
                erros.Add("O condutor deve possuir habilitação");

			return erros;
		}
        #region validacoes

        

        public static bool MenorDeIdade(DateTime dataNascimento)
        {
            // Calcula a idade
            int idade = DateTime.Now.Year - dataNascimento.Year;

            // Ajusta a idade se o aniversário ainda não tiver ocorrido no ano atual
            if (DateTime.Now < dataNascimento.AddYears(idade))
            {
                idade--;
            }

            // Verifica se a pessoa é menor de idade
            return idade < 18;
        }

        public static bool ValidarCPF(string cpf)
        {
            // Remove pontos e hifens
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (CPF inválido)
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados são iguais aos do CPF informado
            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }
#endregion
    }
}
