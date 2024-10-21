using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class PetsDoCsv : LeitorDeArquivoCsv<Pet>
    {
        public PetsDoCsv(string? caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
        {
        }

        public override Pet CriarDalinhaCsv(string linha)
        {
            string[] propriedades = linha.Split(';');
            bool guidValido = Guid.TryParse(propriedades[0], out Guid id);

            if (!guidValido) throw new ArgumentNullException("Identificador do pet inválido!");

            bool tipoValido = Enum.TryParse(propriedades[2], out TipoPet tipo);

            if (!tipoValido) throw new ArgumentNullException("Tipo do pet inválido!");

            return new Pet(id: id, nome: propriedades[1], tipo: tipo);
        }
    }
}
