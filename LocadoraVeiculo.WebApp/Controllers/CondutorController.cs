using AutoMapper;
using LocadoraDeVeiculos.WebApp.Controllers.Compartilhado;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraVeiculo.WebApp.Models;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraVeiculo.WebApp.Controllers
{
    public class CondutorController : WebControllerBase
    {
        private readonly ServicoCondutor servico;
        private readonly IMapper mapeador;

        public CondutorController(ServicoCondutor servico, IMapper mapeador)
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

            var condutores = resultado.Value;

            var listarCondutoresVm = mapeador.Map<IEnumerable<ListarCondutorViewModel>>(condutores);

            return View(listarCondutoresVm);
        }

        public IActionResult Inserir()
        {
            return View(new InserirCondutorViewModel());
        }

        [HttpPost]
        public IActionResult Inserir(InserirCondutorViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(inserirVm);

            var condutor = mapeador.Map<Condutor>(inserirVm);

            var resultado = servico.Inserir(condutor);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(inserirVm);
            }

            ApresentarMensagemSucesso($"O condutor ID [{condutor.Id}] foi inserido com sucesso!");

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

            var condutor = resultado.Value;

            var editarVm = mapeador.Map<FormularioCondutorViewModel>(condutor);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(FormularioCondutorViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var condutor = mapeador.Map<Condutor>(editarVm);

            var resultado = servico.Editar(condutor);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(editarVm);
            }

            ApresentarMensagemSucesso($"O condutor ID [{condutor.Id}] foi editado com sucesso!");

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

            var condutor = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesCondutorViewModel>(condutor);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesCondutorViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(detalhesVm);
            }

            ApresentarMensagemSucesso($"O condutor ID [{detalhesVm.Id}] foi excluído com sucesso!");

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

            var condutor = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesCondutorViewModel>(condutor);

            return View(detalhesVm);
        }
    }
}
