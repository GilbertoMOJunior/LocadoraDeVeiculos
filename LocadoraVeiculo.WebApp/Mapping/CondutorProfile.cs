using AutoMapper;
using LocadoraVeiculo.WebApp.Models;
using LocadoraVeiculos.Dominio.ModuloCondutor;

namespace LocadoraVeiculo.WebApp.Mapping
{
    public class CondutorProfile : Profile
    {
        public CondutorProfile()
        {
            CreateMap<FormularioCondutorViewModel, Condutor>();

            CreateMap<DetalhesCondutorViewModel, Condutor>()
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(c => c.DataNascimento.ToShortDateString()));

            CreateMap<ListarCondutorViewModel, Condutor>()
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(c => c.DataNascimento.ToShortDateString()));
        }
    }
}
