using FluentResults;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private readonly IRepositorioGrupoDeVeiculos repositorioGrupo;

        public ServicoGrupoVeiculos(IRepositorioGrupoDeVeiculos repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        public Result<GrupoDeVeiculos> Inserir(GrupoDeVeiculos grupo)
        {
            repositorioGrupo.Inserir(grupo);

            return Result.Ok(grupo);
        }

        public Result<GrupoDeVeiculos> Editar(GrupoDeVeiculos grupoAtualizado)
        {
            var grupo = repositorioGrupo.SelecionarPorId(grupoAtualizado.Id);

            if (grupo is null)
                return Result.Fail("O grupo nao foi encontrado");

            grupo.Nome = grupoAtualizado.Nome;

            repositorioGrupo.Editar(grupo);

            return Result.Ok(grupo);
        }

        public Result<GrupoDeVeiculos> Excluir(int grupoId)
        {
            var grupo = repositorioGrupo.SelecionarPorId(grupoId);

            if (grupo is null)
                return Result.Fail("O grupo nao foi encontrado");

            repositorioGrupo.Excluir(grupo);

            return Result.Ok(grupo);
        }

        public Result<GrupoDeVeiculos> SelecionarPorId(int grupoId)
        {
            var grupo = repositorioGrupo.SelecionarPorId(grupoId);

            if (grupo is null)
                return Result.Fail("O grupo nao foi encontrado");

            return Result.Ok(grupo);
        }

        public Result<List<GrupoDeVeiculos>> SelecionarTodos()
        {
            var grupos = repositorioGrupo.SelecionarTodos();

            return Result.Ok(grupos);
        }
    }
}
