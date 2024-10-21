using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Testes.Builder;
using FluentResults;
using Moq;

namespace Alura.Adopet.Testes.Comandos
{
    public class ShowTest
    {
        [Fact]
        public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
        {
            //Arrange
            List<Pet>? listaDePets = new();
            Pet pet = new(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);

            listaDePets.Add(pet);

            Mock<ILeitorDeArquivos<Pet>> leitor = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);

            //Act
            Result retorno = await new Show(leitor.Object).ExecutarAsync();

            //Assert
            Assert.NotNull(retorno);

            SuccessWithPets resultado = (SuccessWithPets)retorno.Successes[0];

            Assert.Equal("Exibição do arquivo realizda com Sucesso!", resultado.Message);
        }
    }
}
