using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class PetsDoJson : LeitorDeArquivoJson<Pet>
    {
        public PetsDoJson(string? caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
        {
        }
    }
}
