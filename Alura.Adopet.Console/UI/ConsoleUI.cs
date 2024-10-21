using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using FluentResults;

namespace Alura.Adopet.Console.UI
{
    internal static class ConsoleUI
    {
        public static void ExibeResultado(Result result)
        {
            try
            {
                System.Console.ForegroundColor = ConsoleColor.Green;

                if (result.IsFailed)
                {
                    ExibeFalha(result);
                }
                else
                {
                    ExibeSucesso(result);
                }
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ExibeSucesso(Result result)
        {
            ISuccess sucesso = result.Successes.First();

            switch (sucesso)
            {
                case SuccessWithPets s:
                    ExibirPets(s);

                    break;
                case SuccessWithClientes s:
                    ExibirClientes(s);

                    break;
                case SuccessWithDocs d:
                    ExibeDocumentacao(d);

                    break;
            }
        }

        private static void ExibeDocumentacao(SuccessWithDocs documentacaoComando)
        {
            System.Console.WriteLine("Lista de comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");

            foreach (string pet in documentacaoComando.Documentacao)
            {
                System.Console.WriteLine(pet);
            }

            System.Console.WriteLine(documentacaoComando.Message);
        }

        private static void ExibirPets(SuccessWithPets sucesso)
        {
            foreach (Pet pet in sucesso.Data)
            {
                System.Console.WriteLine(pet);
            }

            System.Console.WriteLine(sucesso.Message);
        }

        private static void ExibirClientes(SuccessWithClientes sucesso)
        {
            foreach (Cliente cliente in sucesso.Data)
            {
                System.Console.WriteLine(cliente);
            }

            System.Console.WriteLine(sucesso.Message);
        }

        private static void ExibeFalha(Result result)
        {
            IError? error = result.Errors.First();

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"Aconteceu um exceção: {error.Message}");
        }
    }
}
