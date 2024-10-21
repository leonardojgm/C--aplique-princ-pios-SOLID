using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Mail;
using Alura.Adopet.Console.Servicos.Progresso;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos
{
    public class ImportFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            IApiService<Pet> httpClient = new PetService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
            ILeitorDeArquivos<Pet>? leitorDeArquivo = LeitorDeArquivoFactory.CreatePetFrom(argumentos.Length == 2 ? argumentos[1] : null);

            if (leitorDeArquivo is null) { return null; }

            Import import = new(httpClient, leitorDeArquivo);

            import.DepoisDaExecucao += EnvioDeEmail.Disparar;
            import.ProgressChanged += ProcessaProgresso.ProgressChanged;

            return import;
        }
    }
}
