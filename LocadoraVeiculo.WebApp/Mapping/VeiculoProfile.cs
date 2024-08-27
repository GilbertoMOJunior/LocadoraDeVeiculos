using AutoMapper;
using LocadoraVeiculo.WebApp.Models;
using LocadoraVeiculos.Dominio;

namespace LocadoraVeiculo.WebApp.Mapping
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
	        CreateMap<InserirVeiculoViewModel, Veiculo>();
	        CreateMap<EditarVeiculoViewModel, Veiculo>();

            CreateMap<Veiculo, ListarVeiculoViewModel>()
                .ForMember(d => d.GrupoVeiculos, 
                    opt => opt.MapFrom(src => src.Grupo.Nome)
                    );

            CreateMap<Veiculo, DetalhesVeiculoViewModel>()
	            .ForMember(
		            dest => dest.GrupoVeiculos,
		            opt => opt.MapFrom(src => src.Grupo!.Nome)
	            );

            CreateMap<Veiculo, EditarVeiculoViewModel>();
        }
    }
}
