using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Testes.Builder;
using FluentResults;
using Moq;

namespace Alura.Adopet.Testes.Comandos
{
    public class ListTest
    {
        [Fact]
        public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
        {
            //Arrange
            List<Pet>? listaDePets = new();
            Pet pet = new(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);

            listaDePets.Add(pet);

            Mock<IApiService<Pet>> httpClientPet = ApiServiceMockBuilder.CriaMockList(listaDePets);

            //Act
            Result retorno = await new Console.Comandos.List(httpClientPet.Object).ExecutarAsync();

            //Assert
            SuccessWithPets resultado = (SuccessWithPets)retorno.Successes[0];

            Assert.Single(resultado.Data);
        }
    }
}
