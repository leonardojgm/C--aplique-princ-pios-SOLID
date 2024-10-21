using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos
{
    public class LeitorDeArquivoFactoryTest
    {
        [Fact]
        public void QuantoExtensaoForCsvDeveRetornarTipoLeitorDeArquivoCsv()
        {
            // arrange
            string caminhoArquivo = "pets.csv";

            // act
            ILeitorDeArquivos<Pet>? leitor = LeitorDeArquivoFactory.CreatePetFrom(caminhoArquivo);

            // assert
            Assert.IsType<PetsDoCsv>(leitor);
        }

        [Fact]
        public void QuantoExtensaoForJsonDeveRetornarTipoLeitorDeArquivoJson()
        {
            // arrange
            string caminhoArquivo = "pets.json";

            // act
            ILeitorDeArquivos<Pet>? leitor = LeitorDeArquivoFactory.CreatePetFrom(caminhoArquivo);

            // assert
            Assert.IsType<PetsDoJson>(leitor);
        }

        [Fact]
        public void QuantoExtensaoNaoSuportadaDeveRetornarNulo()
        {
            // arrange
            string caminhoArquivo = "pets.xsl";

            // act
            ILeitorDeArquivos<Pet>? leitor = LeitorDeArquivoFactory.CreatePetFrom(caminhoArquivo);

            // assert
            Assert.Null(leitor);
        }
    }
}
