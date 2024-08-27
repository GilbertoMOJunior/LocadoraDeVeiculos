using AutoMapper;
using LocadoraDeVeiculos.WebApp.Controllers.Compartilhado;
using LocadoraVeiculo.WebApp.Models;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanos;
using LocadoraVeiculos.Dominio.ModuloPlanos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraVeiculo.WebApp.Controllers
{
	public class PlanosController : WebControllerBase
	{
		private readonly ServicoPlanos servico;
		private readonly ServicoGrupoVeiculos servicoGrupos;
		private readonly IMapper mapeador;

		public PlanosController(
			ServicoPlanos servico,
			ServicoGrupoVeiculos servicoGrupo,
			IMapper mapeador)
		{
			this.servico = servico;
			this.servicoGrupos = servicoGrupo;
			this.mapeador = mapeador;
		}
		public IActionResult Listar()
		{
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var planosCobranca = resultado.Value;

            var listarPlanosVm = mapeador.Map<IEnumerable<ListarPlanoCobrancaViewModel>>(planosCobranca);

            return View(listarPlanosVm);
		}

		public IActionResult Inserir()
		{
			return View(CarregarDadosFormulario());
		}

		[HttpPost]
		public IActionResult Inserir(InserirPlanoCobrancaViewModel inserirVm)
		{
			if (!ModelState.IsValid)
				return View(CarregarDadosFormulario(inserirVm));

			var planoCobranca = mapeador.Map<PlanoCobranca>(inserirVm);

			var resultado = servico.Inserir(planoCobranca);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			ApresentarMensagemSucesso($"O registro ID [{planoCobranca.Id}] foi inserido com sucesso!");

			return RedirectToAction(nameof(Listar));
		}

		public IActionResult Editar(int id)
		{
			var resultado = servico.SelecionarPorId(id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			var planoCobranca = resultado.Value;

			var editarVm = mapeador.Map<EditarPlanoCobrancaViewModel>(planoCobranca);

			var grupos = servicoGrupos.SelecionarTodos().Value;

			editarVm.GruposVeiculos = grupos
				.Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

			return View(editarVm);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(EditarPlanoCobrancaViewModel editarVm)
		{
			if (!ModelState.IsValid)
				return View(CarregarDadosFormulario(editarVm));

			var planoCobranca = mapeador.Map<PlanoCobranca>(editarVm);

			var resultado = servico.Editar(planoCobranca);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			ApresentarMensagemSucesso($"O registro ID [{planoCobranca.Id}] foi editado com sucesso!");

			return RedirectToAction(nameof(Listar));
		}

		public IActionResult Excluir(int id)
		{
			var resultado = servico.SelecionarPorId(id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			var planoCobranca = resultado.Value;

			var detalhesVm = mapeador.Map<DetalhesPlanoCobrancaViewModel>(planoCobranca);

			return View(detalhesVm);
		}

		[HttpPost]
		public IActionResult Excluir(DetalhesPlanoCobrancaViewModel detalhesVm)
		{
			var resultado = servico.Excluir(detalhesVm.Id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

			return RedirectToAction(nameof(Listar));
		}

		public IActionResult Detalhes(int id)
		{
			var resultado = servico.SelecionarPorId(id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			var planoCobranca = resultado.Value;

			var detalhesVm = mapeador.Map<DetalhesPlanoCobrancaViewModel>(planoCobranca);

			return View(detalhesVm);
		}

		private FormularioPlanoCobrancaViewModel? CarregarDadosFormulario(FormularioPlanoCobrancaViewModel? dadosPrevios = null)
		{
			var resultadoGrupos = servicoGrupos.SelecionarTodos();

			if (resultadoGrupos.IsFailed)
			{
				ApresentarMensagemFalha(resultadoGrupos.ToResult());

				return null;
			}

			if (dadosPrevios is null)
			{
				var formularioVm = new FormularioPlanoCobrancaViewModel
				{
					GruposVeiculos = resultadoGrupos.Value
						.Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
				};

				return formularioVm;
			}

			dadosPrevios.GruposVeiculos = resultadoGrupos.Value
				.Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

			return dadosPrevios;
		}
	}
}
