using FluentResults;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Dominio.ModuloEndereco;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
	public class ServicoEndereco
	{
		private readonly IRepositorioEndereco repositorioEndereco;

		public ServicoEndereco(IRepositorioEndereco repositorioEndereco)
		{
			this.repositorioEndereco = repositorioEndereco;
		}

		public Result<Endereco> Inserir(Endereco endereco)
		{
			repositorioEndereco.Inserir(endereco);

			return Result.Ok(endereco);
		}

		public Result<Endereco> Editar(Endereco enderecoAtualizado)
		{
			var endereco = repositorioEndereco.SelecionarPorId(enderecoAtualizado.Id);

			if (endereco is null)
				return Result.Fail("O grupo nao foi encontrado");

			endereco.Estado = enderecoAtualizado.Estado;
			endereco.Cidade = enderecoAtualizado.Cidade;
			endereco.Bairro = enderecoAtualizado.Bairro;
			endereco.Rua = enderecoAtualizado.Rua;
			endereco.Numero = enderecoAtualizado.Numero;

			repositorioEndereco.Editar(endereco);

			return Result.Ok(endereco);
		}

		public Result<Endereco> Excluir(int enderecoId)
		{
			var endereco = repositorioEndereco.SelecionarPorId(enderecoId);

			if (endereco is null)
				return Result.Fail("O endereço nao foi encontrado");

			repositorioEndereco.Excluir(endereco);

			return Result.Ok(endereco);
		}

		public Result<Endereco> SelecionarPorId(int enderecoId)
		{
			var endereco = repositorioEndereco.SelecionarPorId(enderecoId);

			if (endereco is null)
				return Result.Fail("O endereço nao foi encontrado");

			return Result.Ok(endereco);
		}

		public Result<List<Endereco>> SelecionarTodos()
		{
			var endereco = repositorioEndereco.SelecionarTodos();

			return Result.Ok(endereco);
		}
	}
}