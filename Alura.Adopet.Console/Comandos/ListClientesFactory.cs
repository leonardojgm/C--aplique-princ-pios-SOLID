using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos
{
    public class ListClientesFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            IApiService<Cliente> httpClientList = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));

            return new ListClientes(httpClientList);
        }
    }
}
