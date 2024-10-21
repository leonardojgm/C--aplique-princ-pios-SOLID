using Alura.Adopet.Console.Comandos;
using FluentResults;

namespace Alura.Adopet.Testes.Comandos
{
    public class HelpTest
    {
        [Fact]
        public async Task QuandoComandoNaoExistirDeveRetornarFalha()
        {
            //Arrange
            string comando = "Inválido";
            Help help = new(comando);
            
            //Act
            Result resultado = await help.ExecutarAsync();

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.IsFailed);
        }

        [Theory]
        [InlineData("help")]
        [InlineData("show")]
        [InlineData("list")]
        [InlineData("import")]
        public async Task QuandoComandoExistirDeveRetornarSucesso(string comando)
        {
            //Arrange
            Help help = new(comando);

            //Act
            Result resultado = await help.ExecutarAsync();

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.IsSuccess);
        }
    }
}
