using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class ClientesDoCsv : LeitorDeArquivoCsv<Cliente>
    {
        public ClientesDoCsv(string? caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
        {
        }

        public override Cliente CriarDalinhaCsv(string linha)
        {
            string[] propriedades = linha.Split(';');
            bool guidValido = Guid.TryParse(propriedades[0], out Guid id);

            if (!guidValido) throw new ArgumentNullException("Identificador do cliente inválido!");

            return new Cliente(id: id, nome: propriedades[1], email: propriedades[2]);
        }
    }
}
