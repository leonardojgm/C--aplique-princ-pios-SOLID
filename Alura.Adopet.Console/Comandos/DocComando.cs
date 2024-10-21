namespace Alura.Adopet.Console.Comandos
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocComando : Attribute
    {
        public string Instrucao { get; }
        public string Documentacao { get; }

        public DocComando(string instrucao, string documentacao)
        {
            Instrucao = instrucao;
            Documentacao = documentacao;
        }
    }
}
