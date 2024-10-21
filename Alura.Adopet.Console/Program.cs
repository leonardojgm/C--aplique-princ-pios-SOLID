using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;
using FluentResults;

IComando? comando = FabricaDeComandos.CriarComando(args);

if (comando is not null)
{
    Result resultado = await comando.ExecutarAsync();

    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}
