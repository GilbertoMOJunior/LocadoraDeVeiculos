using ControleCinema.WebApp.Models;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraVeiculos.WebApp.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;

        public VeiculoController(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public IActionResult Listar()
        {
            var veiculos = repositorioVeiculo.SelecionarTodos();

            var listarVeiculoVm = veiculos
                .Select(v => new ListarVeiculoViewModel
                {
                    Id = v.Id,
                    Placa = v.Placa
                });

            return View(listarVeiculoVm);
        }
    }
}
