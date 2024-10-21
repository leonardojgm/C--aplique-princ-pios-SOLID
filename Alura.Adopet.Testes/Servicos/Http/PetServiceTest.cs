using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Http;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes.Servicos
{
    public class PetServiceTest
    {
        [Fact]
        public async void ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            //Arrange
            Mock<HttpMessageHandler> handlerMock = new();
            HttpResponseMessage response = new()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"
                [
                    {
                        ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                        ""nome"": ""Lima Limão"",
                        ""tipo"": 1
                    }
                ]")
            };

            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            Mock<HttpClient> httpClient = new(MockBehavior.Default, handlerMock.Object);

            httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

            PetService clientePet = new(httpClient.Object);
            
            //Act
            IEnumerable<Pet>? lista = await clientePet.ListAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async void QuandoAPIForaDeveRetornarUmaExcecao()
        {
            //Arrange
            Mock<HttpMessageHandler> handlerMock = new();

            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new SocketException());

            Mock<HttpClient> httpClient = new(MockBehavior.Default, handlerMock.Object);

            httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

            PetService clientePet = new(httpClient.Object);

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await clientePet.ListAsync());
        }
    }
}