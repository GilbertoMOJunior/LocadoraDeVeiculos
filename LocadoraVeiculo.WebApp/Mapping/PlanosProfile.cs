using AutoMapper;
using LocadoraVeiculo.WebApp.Models;
using LocadoraVeiculos.Dominio.ModuloPlanos;

namespace LocadoraVeiculo.WebApp.Mapping
{
    public class PlanosProfile : Profile
    {
        public PlanosProfile()
        {
            CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>();
            CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();

            CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
                .ForMember(
                    dest => dest.GrupoVeiculos,
                    opt => opt.MapFrom(src => src.GrupoVeiculos!.Nome));

            CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
                .ForMember(
                    dest => dest.GrupoVeiculos,
                    opt => opt.MapFrom(src => src.GrupoVeiculos!.Nome));

            CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>();
        }
    }
}
