using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;

namespace LocadoraVeiculo.WebApp.Mapping
{
    public class GrupoVeiculosProfile : Profile
    {
        public GrupoVeiculosProfile()
        {
            CreateMap<InserirGrupoVeiculosViewModel, GrupoDeVeiculos>();
            CreateMap<EditarGrupoVeiculosViewModel, GrupoDeVeiculos>();

            CreateMap<GrupoDeVeiculos, ListarGrupoVeiculosViewModel>();
            CreateMap<GrupoDeVeiculos, DetalhesGrupoVeiculosViewModel>();
            CreateMap<GrupoDeVeiculos, EditarGrupoVeiculosViewModel>();
        }
    }
}
