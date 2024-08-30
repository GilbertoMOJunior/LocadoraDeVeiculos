using FluentResults;
using LocadoraVeiculos.Dominio.ModuloCliente;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
	public class ServicoCliente
	{
		private readonly IRepositorioCliente repositorioCliente;

		public ServicoCliente(IRepositorioCliente repositorioCliente)
		{
			this.repositorioCliente = repositorioCliente;
		}

		public Result<Cliente> Inserir(Cliente cliente)
		{
			repositorioCliente.Inserir(cliente);

			return Result.Ok(cliente);
		}

		public Result<Cliente> Editar(Cliente clienteAtualizado)
		{
			var cliente = repositorioCliente.SelecionarPorId(clienteAtualizado.Id);

			if (cliente is null)
				return Result.Fail("O cliente nao foi encontrado");

			cliente.Nome = clienteAtualizado.Nome;
			cliente.Email = clienteAtualizado.Email;
			cliente.Telefone = clienteAtualizado.Telefone;
			cliente.EnderecoId = clienteAtualizado.EnderecoId;
			cliente.TipoCadastro = clienteAtualizado.TipoCadastro;
			cliente.NumeroDocumento = clienteAtualizado.NumeroDocumento;
            cliente.Endereco = clienteAtualizado.Endereco;

			repositorioCliente.Editar(cliente);

			return Result.Ok(cliente);
		}

		public Result<Cliente> Excluir(int clienteId)
		{
			var cliente = repositorioCliente.SelecionarPorId(clienteId);

			if (cliente is null)
				return Result.Fail("O cliente nao foi encontrado");

			repositorioCliente.Excluir(cliente);

			return Result.Ok(cliente);
		}

		public Result<Cliente> SelecionarPorId(int clienteId)
		{
			var cliente = repositorioCliente.SelecionarPorId(clienteId);

			if (cliente is null)
				return Result.Fail("O cliente nao foi encontrado");

			return Result.Ok(cliente);
		}

		public Result<List<Cliente>> SelecionarTodos()
		{
			var cliente = repositorioCliente.SelecionarTodos();

			return Result.Ok(cliente);
		}
	}
}