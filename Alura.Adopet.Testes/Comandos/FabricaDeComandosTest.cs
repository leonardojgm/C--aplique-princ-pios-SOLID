using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes.Comandos
{
    public class FabricaDeComandosTest
    {
        [Theory]
        [InlineData("import", "Import")]
        [InlineData("import-clientes", "ImportClientes")]
        [InlineData("show", "Show")]
        [InlineData("list", "List")]
        [InlineData("help", "Help")]
        public void DadoParametroValidoDeveRetornarObjetoNaoNulo(string instrucao, string nomeTipo)
        {
            // arrange
            string[] args = new[] { instrucao, "lista.csv" };
            // act
            var comando = FabricaDeComandos.CriarComando(args);
            // assert
            Assert.NotNull(comando);
            Assert.Equal(nomeTipo, comando.GetType().Name);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            //Arrange
            string[] args = { "import", "lista.csv" };

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(args);

            //Assert
            Assert.IsType<Import>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoList()
        {
            //Arrange
            string[] args = { "list", "lista.csv" };

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(args);

            //Assert
            Assert.IsType<List>(comando);
        }

        [Fact]
        public void DadoUmParametroInvalidoDeveRetornarNulo()
        {
            //Arrange
            string[] args = { "invalid", "lista.csv" };

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(args);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArqumentosNuloDeveRetornarNulo()
        {
            //Arrange + Act
            IComando? comando = FabricaDeComandos.CriarComando(null);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArqumentosVazioDeveRetornarNulo()
        {
            //Arrange
            string[] args = Array.Empty<string>();

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(args);

            //Assert
            Assert.Null(comando);
        }
    }
}
