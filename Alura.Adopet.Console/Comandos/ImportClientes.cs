using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import-clientes", documentacao: "adopet import-clientes <arquivo> comando que realiza a importação do arquivo de clientes.")]
    public class ImportClientes : IComando
    {
        private readonly IApiService<Cliente> apiService;
        private readonly ILeitorDeArquivos<Cliente> leitorDeArquivo;

        public ImportClientes(IApiService<Cliente> apiService, ILeitorDeArquivos<Cliente> leitor)
        {
            this.apiService = apiService;
            this.leitorDeArquivo = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                IEnumerable<Cliente>? lista = leitorDeArquivo.RealizaLeitura();

                if (lista is null)
                {
                    return Result.Fail(new Error("Importação falhou!"));
                }

                foreach (Cliente cliente in lista)
                {
                    await apiService.CreateAsync(cliente);
                }

                return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}
