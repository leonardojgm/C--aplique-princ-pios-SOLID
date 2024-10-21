using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Servicos.Http
{
    public class AdopetAPIClientFactory : IHttpClientFactory
    {
        private readonly string url;

        public AdopetAPIClientFactory(string url)
        {
            this.url = url;
        }

        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);

            return _client;
        }
    }
}
