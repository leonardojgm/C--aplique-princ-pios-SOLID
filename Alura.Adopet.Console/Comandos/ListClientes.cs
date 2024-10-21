using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list-clientes", documentacao: "adopet list-clientes comando que exibe no terminal o conteúdo de clientes na base de dados do AdoPet.")]
    public class ListClientes : IComando
    {
        private readonly IApiService<Cliente> service;

        public ListClientes(IApiService<Cliente> service)
        {
            this.service = service;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                IEnumerable<Cliente>? clientes = await service.ListAsync();

                if (clientes != null && clientes.Any())
                {
                    return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Exibição do arquivo realizada com Sucesso!"));
                }
                else
                {
                    throw new Exception("Nenhum cliente encontrado!");
                }
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception));
            }
        }
    }
}
