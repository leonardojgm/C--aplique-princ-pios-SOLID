using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes.Util
{
    public class LeitorDeArquivoJsonTest : IDisposable
    {
        private readonly string caminhoArquivo;

        public LeitorDeArquivoJsonTest()
        {
            //Setup
            string conteudo = @"[
                                  {
                                    ""Id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                                    ""Nome"": ""Lima"",
                                    ""Tipo"": 1
                                  }
                                ]";
            string nomeRandomico = $"{Guid.NewGuid()}.json";

            File.WriteAllText(nomeRandomico, conteudo);

            caminhoArquivo = Path.GetFullPath(nomeRandomico);
        }

        [Fact]
        public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
        {
            //Arrange + Act
            var listaDePets = new PetsDoJson(caminhoArquivo).RealizaLeitura()!;

            //Assert
            Assert.NotNull(listaDePets);
            Assert.Single(listaDePets);
            Assert.IsType<List<Pet>?>(listaDePets);
        }

        [Fact]
        public void QuandoArquivoNaoExistenteDeveRetornarNulo()
        {
            //Arrange + Act
            var listaDePets = new PetsDoJson("").RealizaLeitura();

            //Assert
            Assert.Null(listaDePets);
        }

        [Fact]
        public void QuandoArquivoForNuloDeveRetornarNulo()
        {
            //Arrange + Act
            var listaDePets = new PetsDoJson(null).RealizaLeitura();

            //Assert
            Assert.Null(listaDePets);
        }

        public void Dispose()
        {
            //ClearDown
            File.Delete(caminhoArquivo);

            GC.SuppressFinalize(this);
        }
    }
}
