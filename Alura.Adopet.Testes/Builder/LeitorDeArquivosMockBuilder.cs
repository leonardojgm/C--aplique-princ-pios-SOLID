using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<ILeitorDeArquivos<T>> CriaMock<T>(List<T> lista)
        {
            Mock<ILeitorDeArquivos<T>> leitorDeArquivo = new();

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(lista);

            return leitorDeArquivo;
        }
    }
}
