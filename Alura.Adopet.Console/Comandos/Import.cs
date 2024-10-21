using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando, IDepoisDaExecucao, ITrabalhoEmProgresso
    {
        private readonly IApiService<Pet> clientPet;
        private readonly ILeitorDeArquivos<Pet> leitorDeArquivo;
        public event Action<Result>? DepoisDaExecucao;
        public event Action<int, int>? ProgressChanged;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivos<Pet> leitorDeArquivo)
        {
            this.clientPet = clientPet;
            this.leitorDeArquivo = leitorDeArquivo;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await ImportacaoArquivoPet();
        }

        private async Task<Result> ImportacaoArquivoPet()
        {
            try
            {
                IEnumerable<Pet> listaDePets = this.leitorDeArquivo.RealizaLeitura()!;
                int i = 0;

                foreach (Pet pet in listaDePets)
                {
                    await clientPet.CreateAsync(pet);

                    i++;

                    OnProgressChanged(i, listaDePets.Count());
                }

                Result resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Importação Realizada com Sucesso!"));

                DepoisDaExecucao?.Invoke(resultado);

                return resultado;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }

        private void OnProgressChanged(int i, int total)
        {
            ProgressChanged?.Invoke(i, total);

            Thread.Sleep(100);
        }
    }
}
