using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Util;
using FluentResults;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help", documentacao: "adopet help <parametro> ou simplemente adopet help comando que exibe informações de ajuda dos comandos.")]
    public class Help : IComando
    {
        private readonly Dictionary<string, DocComando> docs;
        private readonly string? comando;

        public Help(string? comando)
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
            this.comando = comando;
        }

        public Task<Result> ExecutarAsync()
        {
            return Task.FromResult(GerarDocumentacao());
        }

        private Result GerarDocumentacao()
        {
            try
            {
                List<string> resultado = new();

                if (this.comando is null)
                {
                    foreach (DocComando doc in this.docs.Values)
                    {
                        resultado.Add(doc.Documentacao);
                    }
                }
                else
                {
                    if (docs.ContainsKey(this.comando))
                    {
                        DocComando comando = this.docs[this.comando];

                        resultado.Add(comando.Documentacao);
                    }
                    else
                    {
                        resultado.Add("Comando não encontrado!");

                        throw new ArgumentException();
                    }
                }

                return Result.Ok().WithSuccess(new SuccessWithDocs(resultado, "Exibição da documentação realizda com Sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(exception));
            }
        }
    }
}
