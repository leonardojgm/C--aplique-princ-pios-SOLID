using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos
{
    public class ListFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            IApiService<Pet> httpClientList = new PetService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));

            return new List(httpClientList);
        }
    }
}
