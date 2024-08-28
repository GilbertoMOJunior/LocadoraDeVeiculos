using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculo.WebApp.Models
{
    public class FormularioCondutorViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF deve conter ao menos 11 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O número da CNH é obrigatório")]
        [MinLength(9, ErrorMessage = "O número da CNH deve conter ao menos 9 caracteres")]
        public string NumeroCNH { get; set; }
    }

    public class InserirCondutorViewModel : FormularioCondutorViewModel
    {
    }

    public class ListarCondutorViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string NumeroCNH { get; set; }
    }

    public class DetalhesCondutorViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string NumeroCNH { get; set; }
    }
}
