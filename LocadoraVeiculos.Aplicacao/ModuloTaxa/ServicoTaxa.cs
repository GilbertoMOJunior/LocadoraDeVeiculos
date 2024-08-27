using FluentResults;
using LocadoraVeiculos.Dominio.ModuloTaxa;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private readonly IRepositorioTaxa repositorioTaxa;
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            repositorioTaxa.Inserir(taxa);

            return Result.Ok(taxa);
        }

        public Result<Taxa> Editar(Taxa taxaAtualizada)
        {
            var taxa = repositorioTaxa.SelecionarPorId(taxaAtualizada.Id);

            if (taxa is null)
                return Result.Fail("A taxa não foi encontrada!");

            taxa.Nome = taxaAtualizada.Nome;
            taxa.TipoCobranca = taxaAtualizada.TipoCobranca;
            taxa.Valor = taxaAtualizada.Valor;

            repositorioTaxa.Editar(taxa);

            return Result.Ok(taxa);
        }

        public Result<Taxa> Excluir(int taxaId)
        {
            var taxa = repositorioTaxa.SelecionarPorId(taxaId);

            if (taxa is null)
                return Result.Fail("A taxa não foi encontrada!");

            repositorioTaxa.Excluir(taxa);

            return Result.Ok(taxa);
        }

        public Result<Taxa> SelecionarPorId(int taxaId)
        {
            var taxa= repositorioTaxa.SelecionarPorId(taxaId);

            if (taxa is null)
                return Result.Fail("A taxa não foi encontrada!");

            return Result.Ok(taxa);
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            var taxas= repositorioTaxa.SelecionarTodos();

            return Result.Ok(taxas);
        }
    }
}
