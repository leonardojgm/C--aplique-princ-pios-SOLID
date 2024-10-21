using Alura.Adopet.Console.Comandos;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions
{
    public static class ComandosExtensions
    {
        public static Type? GetTipoComando(this Assembly assembly, string instrucao)
        {
            return assembly.GetTypes() // Lista de tipos
                .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando))) // Filtra apenas os tipos concretos que implementam IComando
                .FirstOrDefault(t => t.GetCustomAttributes<DocComando>()
                .Any(dc => dc.Instrucao == instrucao)); // Recupara apenas aquele que atende à instrucao
        }

        public static IEnumerable<IComandoFactory?> GetFabricas(this Assembly assembly)
        {
            return assembly.GetTypes() // Lista de tipos
                .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory))) // Filtra apenas os tipos concretos queimplementam IComandoFactory
                .Select(f => Activator.CreateInstance(f) as IComandoFactory); // Cria instâncias de cada fábrica (não é o ideal)
        }
    }
}
