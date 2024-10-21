using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos
{
    public class ImportClientesFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            IApiService<Cliente> httpClientCliente = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
            ILeitorDeArquivos<Cliente>? leitorDeArquivoCliente = LeitorDeArquivoFactory.CreateClienteFrom(argumentos.Length == 2 ? argumentos[1] : null);

            if (leitorDeArquivoCliente is null) { return null; }

            return new ImportClientes(httpClientCliente, leitorDeArquivoCliente);
        }
    }
}
