using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    internal static class ApiServiceMockBuilder
    {
        public static Mock<IApiService<T>> CriaMock<T>()
        {
            Mock<IApiService<T>> httpClient = new();

            return httpClient;
        }
        public static Mock<IApiService<T>> CriaMockList<T>(List<T> lista)
        {
            Mock<IApiService<T>> httpClient = new();

            httpClient.Setup(_ => _.ListAsync()).ReturnsAsync(lista);

            return httpClient;
        }
    }
}
