using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class List : IComando
    {
        private readonly IApiService<Pet> clientPet;

        public List(IApiService<Pet> clientPet)
        {
            this.clientPet = clientPet;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await ExibirLista();
        }

        internal async Task<Result> ExibirLista()
        {
            try
            {
                IEnumerable<Pet>? listaDePets = await this.clientPet.ListAsync();

                if (listaDePets != null && listaDePets.Any())
                {
                    return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição do arquivo realizada com Sucesso!"));
                }
                else
                {
                    throw new Exception("Nenhum pet encontrado!");
                }
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception));
            }
        }
    }
}
