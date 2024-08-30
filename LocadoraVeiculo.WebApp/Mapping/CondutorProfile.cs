using AutoMapper;
using LocadoraVeiculo.WebApp.Models;
using LocadoraVeiculos.Dominio.ModuloCondutor;

namespace LocadoraVeiculo.WebApp.Mapping
{
    public class CondutorProfile : Profile
    {
        public CondutorProfile()
        {
            CreateMap<EditarCondutorViewModel, Condutor>();
            CreateMap<InserirCondutorViewModel, Condutor>();

            CreateMap<DetalhesCondutorViewModel, Condutor>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(x => x.Nome)
                )
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(c => c.DataNascimento.ToShortDateString()));

            CreateMap<ListarCondutorViewModel, Condutor>()
                .ForMember(d => d.Cliente,
                    opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(c => c.DataNascimento.ToShortDateString()));

            CreateMap<Condutor, InserirCondutorViewModel>();
        }
    }
}
