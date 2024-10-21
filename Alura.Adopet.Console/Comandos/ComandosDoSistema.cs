using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos
{
    internal class ComandosDoSistema
    {
        private readonly Dictionary<string, IComando> comandosDoSistema;
        private readonly PetService httpClient;
        private readonly PetsDoCsv leitorDeArquivo;

        public ComandosDoSistema(string[] args)
        {
            httpClient = new(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
            leitorDeArquivo = new PetsDoCsv(args.Length == 2 ? args[1] : null);
            comandosDoSistema = new()
            {
                {"help",new Help(args.Length == 2 ? args[1] : null) },
                {"import",new Import(httpClient, leitorDeArquivo) },
                {"list",new List(httpClient) },
                {"show",new Show(leitorDeArquivo) },
            };
        }

        public IComando? this[string key] => comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
    }
}
