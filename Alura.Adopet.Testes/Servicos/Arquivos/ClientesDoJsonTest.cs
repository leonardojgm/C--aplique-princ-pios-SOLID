using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos
{
    public class ClientesDoJsonTest : IDisposable
    {
        private readonly string caminhoArquivo;

        public ClientesDoJsonTest()
        {
            //Setup
            string conteudo = @"
                [
                  {
                    ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                    ""Nome"": ""Mancha"",
                    ""Tipo"": 1
                  },
                  {
                    ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                    ""Nome"": ""Alvo"",
                    ""Tipo"": 1
                  },
                  {
                    ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                    ""Nome"": ""Pinta"",
                    ""Tipo"": 1
                  }
                ]
            ";

            string nomeRandomico = $"{Guid.NewGuid()}.json";

            File.WriteAllText(nomeRandomico, conteudo);

            caminhoArquivo = Path.GetFullPath(nomeRandomico);
        }

        [Fact]
        public void QuandoArquivoExistenteDeveRetornarUmaListaDeClientes()
        {
            //Arrange            
            //Act
            var lista = new ClientesDoJson(caminhoArquivo).RealizaLeitura()!;

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count());
        }

        public void Dispose()
        {
            File.Delete(caminhoArquivo);

            GC.SuppressFinalize(this);
        }
    }
}
