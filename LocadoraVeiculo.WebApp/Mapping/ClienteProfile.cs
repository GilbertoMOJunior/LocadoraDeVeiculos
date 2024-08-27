using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraVeiculo.WebApp.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<InserirClienteViewModel, Cliente>()
                .ForMember(
                d => d.Endereco,
                opt => opt.MapFrom(
                    x => new Endereco(x.Estado, x.Cidade, x.Bairro, x.Rua, x.Numero))
                );

            CreateMap<EditarClienteViewModel, Cliente>()
                .ForMember(
                    d => d.Endereco,
                    opt => opt.MapFrom(
                        x => new Endereco(x.Estado, x.Cidade, x.Bairro, x.Rua, x.Numero))
                );

            CreateMap<Cliente, ListarClienteViewModel>()
                .ForMember(
                    dest => dest.TipoCadastro,
                    opt => opt.MapFrom(x => x.TipoCadastro.ToString())
                );

            CreateMap<Cliente, DetalhesClienteViewModel>()
                .ForMember(
                    dest => dest.TipoCadastro,
                    opt => opt.MapFrom(x => x.TipoCadastro.ToString())
                );

            CreateMap<Cliente, EditarClienteViewModel>();
        }
    }
}
