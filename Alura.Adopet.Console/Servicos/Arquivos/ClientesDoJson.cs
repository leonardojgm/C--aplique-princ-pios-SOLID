using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class ClientesDoJson : LeitorDeArquivoJson<Cliente>
    {
        public ClientesDoJson(string? caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
        {
        }
    }
}
