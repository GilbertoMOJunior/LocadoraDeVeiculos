using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloPlanos
{
	public class PlanoCobranca : EntidadeBase
	{
		public int GrupoVeiculosId { get; set; }
		public GrupoDeVeiculos.GrupoDeVeiculos? GrupoVeiculos { get; set; }

		public decimal PrecoDiarioPlanoDiario{ get; set; }
		public decimal PrecoKmPlanoDiario{ get; set; }

		public decimal KmDisponiveisPlanoControlado  { get; set; }
		public decimal PrecoDiarioPlanoControlado { get; set; }
		public decimal PrecoKmPlanoControlado { get; set; }

		public decimal PrecoDiarioPlanoLivre { get;set; }

		public PlanoCobranca() { }

		public PlanoCobranca(
			int grupoVeiculosId,
			decimal precoDiarioPlanoDiario,
			decimal precoKmPlanoDiario,
			decimal kmsDisponiveisPlanoControlado,
			decimal precoDiarioPlanoControlado,
			decimal precoKmExtrapoladoPlanoControlado,
			decimal precoDiarioPlanoLivre
		)
		{
			GrupoVeiculosId = grupoVeiculosId;

			PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
			PrecoKmPlanoDiario = precoKmPlanoDiario;

			KmDisponiveisPlanoControlado = kmsDisponiveisPlanoControlado;
			PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
			PrecoKmPlanoControlado = precoKmExtrapoladoPlanoControlado;

			PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
		}

		public override List<string> Validar()
		{
			List<string> erros = [];

			if (GrupoVeiculosId == 0)
				erros.Add("O grupo de veiculo é obrigatório");
				
			return erros;
		}
	}
}
