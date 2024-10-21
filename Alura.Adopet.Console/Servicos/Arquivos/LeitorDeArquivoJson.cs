using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public abstract class LeitorDeArquivoJson<T> : ILeitorDeArquivos<T>
    {
        private readonly string? caminhoArquivo;

        public LeitorDeArquivoJson(string? caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IEnumerable<T>? RealizaLeitura()
        {
            if (string.IsNullOrWhiteSpace(caminhoArquivo)) return null;

            using FileStream stream = new(caminhoArquivo, FileMode.Open, FileAccess.Read);

            JsonSerializerOptions jsonOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<T>>(stream, jsonOptions) ?? Enumerable.Empty<T>();
        }
    }
}
