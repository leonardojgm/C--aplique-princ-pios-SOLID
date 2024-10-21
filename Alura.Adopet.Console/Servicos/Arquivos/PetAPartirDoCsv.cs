using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            string[] propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

            if (string.IsNullOrEmpty(linha)) throw new ArgumentNullException("Texto não pode ser vazio!");

            if (propriedades.Length != 3) throw new ArgumentNullException("Texto inválido!");

            bool sucesso = Guid.TryParse(propriedades[0], out Guid petId);

            if (!sucesso) throw new ArgumentNullException("Guid inválido!");

            sucesso = int.TryParse(propriedades[2], out int tipoPet);

            if (!sucesso || tipoPet != 0 && tipoPet != 1) throw new ArgumentNullException("Tipo de Pet inválido!");

            return new Pet(petId, propriedades[1], tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro);
        }
    }
}
