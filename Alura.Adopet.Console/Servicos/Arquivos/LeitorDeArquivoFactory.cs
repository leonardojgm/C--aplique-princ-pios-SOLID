using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public static class LeitorDeArquivoFactory
    {
        public static ILeitorDeArquivos<Pet>? CreatePetFrom(string? caminhoArquivo)
        {
            if (caminhoArquivo is null) return null;

            string extensao = Path.GetExtension(caminhoArquivo);

            return extensao switch
            {
                ".csv" => new PetsDoCsv(caminhoArquivo),
                ".json" => new PetsDoJson(caminhoArquivo),
                _ => null,
            };
        }

        public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string? caminhoArquivo)
        {
            if (caminhoArquivo is null) return null;

            string extensao = Path.GetExtension(caminhoArquivo);

            return extensao switch
            {
                ".csv" => new ClientesDoCsv(caminhoArquivo),
                ".json" => new ClientesDoJson(caminhoArquivo),
                _ => null,
            };
        }
    }
}
