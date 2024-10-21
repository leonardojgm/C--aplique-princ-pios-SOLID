using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http
{
    public class ClienteService : IApiService<Cliente>
    {
        private readonly HttpClient client;

        public ClienteService(HttpClient client)
        {
            this.client = client;
        }

        public Task CreateAsync(Cliente obj)
        {
            return client.PostAsJsonAsync("proprietario/add", obj);
        }

        public async Task<IEnumerable<Cliente>?> ListAsync()
        {
            HttpResponseMessage response = await client.GetAsync("proprietario/list");

            return await response.Content.ReadFromJsonAsync<List<Cliente>>();
        }
    }
}
