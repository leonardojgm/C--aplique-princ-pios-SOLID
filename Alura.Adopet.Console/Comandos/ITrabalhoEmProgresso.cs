namespace Alura.Adopet.Console.Comandos
{
    public interface ITrabalhoEmProgresso
    {
        event Action<int, int> ProgressChanged;
    }
}
