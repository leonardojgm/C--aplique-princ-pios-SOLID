using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public abstract class LeitorDeArquivoCsv<T> : ILeitorDeArquivos<T>
    {
        private readonly string? caminhoDoArquivoASerLido;

        public LeitorDeArquivoCsv(string? caminhoDoArquivoASerLido)
        {
            this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public virtual IEnumerable<T>? RealizaLeitura()
        {
            if (string.IsNullOrWhiteSpace(caminhoDoArquivoASerLido)) return null;

            List<T> lista = new();

            using (StreamReader sr = new(caminhoDoArquivoASerLido))
            {
                while (!sr.EndOfStream)
                {
                    string? linha = sr.ReadLine();

                    if (linha is not null)
                    {
                        T objeto = CriarDalinhaCsv(linha);

                        lista.Add(objeto);
                    }
                }
            }

            return lista;
        }

        public abstract T CriarDalinhaCsv(string linha);
    }
}
