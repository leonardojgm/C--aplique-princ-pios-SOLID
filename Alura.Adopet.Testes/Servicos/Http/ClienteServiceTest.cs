using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes.Servicos
{
    public class ClienteServiceTest
    {
        [Fact]
        public async Task DadaRespostaComVariosClientesDeveRetornarListaNaoVazia()
        {
            //Arrange
            List<Cliente> lista = new()
            {
                new Cliente(Guid.Parse("ed48920c-5adb-4684-9b8f-ba8a94775a11"), "Fulano de Tal", "fulano@example.org"),
                new Cliente(Guid.Parse("456b24f4-19e2-4423-845d-4a80e8854a41"), "José Silva", "silva@example.org")
            };
            Mock<IApiService<Cliente>> mock = ApiServiceMockBuilder.CriaMockList(lista);

            //Act
            IEnumerable<Cliente>? resultado = await mock.Object.ListAsync();

            //Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
            Assert.Equal(2, resultado.Count());
        }
    }
}
