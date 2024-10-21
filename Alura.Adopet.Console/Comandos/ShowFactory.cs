using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos
{
    public class ShowFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(Show)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            ILeitorDeArquivos<Pet>? leitorDeArquivoShow = LeitorDeArquivoFactory.CreatePetFrom(argumentos.Length == 2 ? argumentos[1] : null);

            if (leitorDeArquivoShow is null) { return null; }

            return new Show(leitorDeArquivoShow);
        }
    }
}
