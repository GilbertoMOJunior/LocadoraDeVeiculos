using FluentResults;
using LocadoraVeiculos.Dominio.ModuloPlanos;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanos
{
	public class ServicoPlanos
	{
		private readonly IRepositorioPlanos repositorioPlanos;

		public ServicoPlanos(IRepositorioPlanos repositorioPlanos)
		{
			this.repositorioPlanos = repositorioPlanos;
		}

		public Result<PlanoCobranca> Inserir(PlanoCobranca plano)
		{
			repositorioPlanos.Inserir(plano);

			return Result.Ok(plano);
		}

		public Result<PlanoCobranca> Editar(PlanoCobranca planoAtualizado)
		{
			var plano = repositorioPlanos.SelecionarPorId(planoAtualizado.Id);

			if (plano is null)
				return Result.Fail("O plano de cobrança não foi encontrado!");

			plano.GrupoVeiculosId = planoAtualizado.GrupoVeiculosId;
			plano.PrecoDiarioPlanoDiario = planoAtualizado.PrecoDiarioPlanoDiario;
			plano.PrecoKmPlanoDiario = planoAtualizado.PrecoKmPlanoDiario;
			plano.KmDisponiveisPlanoControlado = planoAtualizado.KmDisponiveisPlanoControlado;
			plano.PrecoDiarioPlanoControlado = planoAtualizado.PrecoDiarioPlanoControlado;
			plano.PrecoKmPlanoControlado = planoAtualizado.PrecoKmPlanoControlado;
			plano.PrecoDiarioPlanoLivre = planoAtualizado.PrecoDiarioPlanoLivre;

			repositorioPlanos.Editar(plano);

			return Result.Ok(plano);
		}

		public Result<PlanoCobranca> Excluir(int planoId)
		{
			var plano = repositorioPlanos.SelecionarPorId(planoId);

			if (plano is null)
				return Result.Fail("O plano de cobrança não foi encontrado!");

			repositorioPlanos.Excluir(plano);

			return Result.Ok(plano);
		}

		public Result<PlanoCobranca> SelecionarPorId(int planoId)
		{
			var plano = repositorioPlanos.SelecionarPorId(planoId);

			if (plano is null)
				return Result.Fail("O plano de cobrança não foi encontrado!");

			return Result.Ok(plano);
		}

		public Result<List<PlanoCobranca>> SelecionarTodos()
		{
			var planos = repositorioPlanos.SelecionarTodos();

			return Result.Ok(planos);
		}
	}
}
