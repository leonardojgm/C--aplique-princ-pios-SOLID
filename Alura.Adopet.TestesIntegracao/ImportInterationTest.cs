using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.TestesIntegracao.Builder;
using Moq;

namespace Alura.Adopet.TestesIntegracao
{
    public class ImportInterationTest
    {
        [Fact]
        public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            //Arrange
            List<Pet> listaDePet = new();
            Pet pet = new(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);

            listaDePet.Add(pet);

            Mock<ILeitorDeArquivos<Pet>> leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePet);
            PetService httpClientPet = new(new AdopetAPIClientFactory("http://localhost:5057").CreateClient("adopet"));
            Import import = new(httpClientPet, leitorDeArquivo.Object);

            //Act
            await import.ExecutarAsync();

            //Assert
            IEnumerable<Pet>? listaPet = await httpClientPet.ListAsync();

            Assert.NotNull(listaPet);
            Assert.NotEmpty(listaPet);
        }
    }
}
