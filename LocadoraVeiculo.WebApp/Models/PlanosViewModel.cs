using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculo.WebApp.Models
{
    public class FormularioPlanoCobrancaViewModel
    {
        [Required(ErrorMessage = "O grupo de veículos é obrigatório")]
        public int GrupoVeiculosId { get; set; }

        [Required(ErrorMessage = "O preço diário do plano diário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano diário deve ser maior que 0")]
        public decimal PrecoDiarioPlanoDiario { get; set; }

        [Required(ErrorMessage = "O preço por quilômetro do plano diário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por quilômetro do plano diário deve ser maior que 0")]
        public decimal PrecoKmPlanoDiario { get; set; }

        [Required(ErrorMessage = "Os quilômetros disponíveis no plano controlado são obrigatórios")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Os quilômetros disponíveis no plano controlado devem ser maiores que 0")]
        public decimal KmDisponiveisPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço diário do plano controlado é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano controlado deve ser maior que 0")]
        public decimal PrecoDiarioPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço por quilômetro extrapolado no plano controlado é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por quilômetro extrapolado no plano controlado deve ser maior que 0")]
        public decimal PrecoKmPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço diário do plano livre é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano livre deve ser maior que 0")]
        public decimal PrecoDiarioPlanoLivre { get; set; }

        public IEnumerable<SelectListItem>? GruposVeiculos { get; set; }
    }

    public class InserirPlanoCobrancaViewModel : FormularioPlanoCobrancaViewModel
    {

    }

    public class EditarPlanoCobrancaViewModel : FormularioPlanoCobrancaViewModel
    {
        public int Id { get; set; }
    }

    public class ListarPlanoCobrancaViewModel
    {
        public int Id { get; set; }
        public string GrupoVeiculos { get; set; }
        public decimal PrecoDiarioPlanoDiario { get; set; }
        public decimal PrecoKmPlanoDiario { get; set; }
        public decimal KmDisponiveisPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoControlado { get; set; }
        public decimal PrecoKmPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoLivre { get; set; }
    }

    public class DetalhesPlanoCobrancaViewModel
    {
        public int Id { get; set; }
        public string GrupoVeiculos { get; set; }
        public decimal PrecoDiarioPlanoDiario { get; set; }
        public decimal PrecoKmPlanoDiario { get; set; }
        public decimal KmDisponiveisPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoControlado { get; set; }
        public decimal PrecoKmPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoLivre { get; set; }
    }
}
