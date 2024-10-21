using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Testes.Util
{
    public class GeraDocumentacaoTest
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionariosNaoVazio()
        {
            //Arrange
            Assembly assemblyComTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;

            //Act
            Dictionary<string, DocComando> dicionario = DocumentacaoDoSistema.ToDictionary(assemblyComTipoDocComando);

            //Assert
            Assert.NotNull(dicionario);
            Assert.NotEmpty(dicionario);
            Assert.Equal(6, dicionario.Count);
        }
    }
}
