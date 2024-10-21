using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Testes.Builder;
using FluentResults;
using Moq;

namespace Alura.Adopet.Testes.Comandos
{
    public class ImportTest
    {
        [Fact]
        public async void QuandoListaVaziaNaoDeveChamarCreatPetAsync()
        {
            //Arrange
            List<Pet> listaDePets = new();
            Mock<ILeitorDeArquivos<Pet>> leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);
            Mock<IApiService<Pet>> httpClientPet = ApiServiceMockBuilder.CriaMockList(listaDePets);
            Import import = new(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync();

            //Assert
            httpClientPet.Verify(_ => _.CreateAsync(It.IsAny<Pet>()), Times.Never());
        }

        //[Fact]
        //public async Task QuandoArquivoNaoExistenteDeveGerarException()
        //{
        //    //Arrange
        //    List<Pet> listaDePets = new();
        //    Mock<LeitorDeArquivo> leitor = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);

        //    leitor.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        //    Mock<HttpClientPet> httpClientPet = HttpClientPetMockBuilder.CriaMock();

        //    string[] args = { "import", "lista.csv" };

        //    Import import = new(httpClientPet.Object, leitor.Object);

        //    //Act+Assert
        //    await Assert.ThrowsAnyAsync<Exception>(() => import.ExecutarAsync(args));
        //}

        [Fact]
        public async Task QuandoArquivoNaoExistenteDeveGerarFalha()
        {
            //Arrange
            List<Pet> listaDePets = new();
            Mock<ILeitorDeArquivos<Pet>> leitor = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);

            leitor.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

            Mock<IApiService<Pet>> httpClientPet = ApiServiceMockBuilder.CriaMockList(listaDePets);

            string[] args = { "import", "lista.csv" };

            Import import = new(httpClientPet.Object, leitor.Object);

            //Act
            Result resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            List<Pet> listaDePets = new();
            Pet pet = new(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);

            listaDePets.Add(pet);

            Mock<ILeitorDeArquivos<Pet>> leitor = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);
            Mock<IApiService<Pet>> httpClientPet = ApiServiceMockBuilder.CriaMockList(listaDePets);

            Import import = new(httpClientPet.Object, leitor.Object);

            //Act
            Result resultado = await import.ExecutarAsync();
            SuccessWithPets sucesso = (SuccessWithPets)resultado.Successes[0];

            //Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal("Lima", sucesso.Data.First().Nome);
        }
    }
}
