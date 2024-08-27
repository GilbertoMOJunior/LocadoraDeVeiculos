using AutoMapper;
using AutoMapper.Configuration.Annotations;
using LocadoraDeVeiculos.WebApp.Controllers.Compartilhado;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraVeiculo.WebApp.Controllers
{
    public class GrupoVeiculosController : WebControllerBase
    {
        private readonly ServicoGrupoVeiculos servico;
        private readonly IMapper mapeador;

        public GrupoVeiculosController(ServicoGrupoVeiculos servico, IMapper mapeador)
        {
            this.servico = servico;
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

            var grupos = resultado.Value;

            var listarGrupoosVm = mapeador
                .Map<IEnumerable<ListarGrupoVeiculosViewModel>>(grupos);

            return View(listarGrupoosVm);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirGrupoVeiculosViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(inserirVm);

            var grupo = mapeador.Map<GrupoDeVeiculos>(inserirVm);

            var resultado = servico.Inserir(grupo);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());
                
                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi inserido com sucesso");

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

            var grupo = resultado.Value;

            var editarVm = mapeador.Map<EditarGrupoVeiculosViewModel>(grupo);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarGrupoVeiculosViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            var grupo = mapeador.Map<GrupoDeVeiculos>(editarVM);

            var resultado = servico.Editar(grupo);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi editado com sucesso!");

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

            var grupo = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesGrupoVeiculosViewModel>(grupo);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesGrupoVeiculosViewModel detalhesVm)
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

            var grupo = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesGrupoVeiculosViewModel>(grupo);

            return View(detalhesVm);
        }
    }
}
