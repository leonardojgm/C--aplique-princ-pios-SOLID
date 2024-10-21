using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que  exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly ILeitorDeArquivos<Pet> leitorDeArquivo;

        public Show(ILeitorDeArquivos<Pet> leitorDeArquivo)
        {
            this.leitorDeArquivo = leitorDeArquivo;
        }

        public Task<Result> ExecutarAsync()
        {
            return Task.FromResult(ExibirConteudoArquivo());
        }

        private Result ExibirConteudoArquivo()
        {
            try
            {
                IEnumerable<Pet> listaDePets = this.leitorDeArquivo.RealizaLeitura()!;

                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição do arquivo realizda com Sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Exibição falhou!").CausedBy(exception));
            }
        }
    }
}
