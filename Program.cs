using Mxemelt.Lex;

namespace Mxemelt;

public static class Program
{
    public static void Main(string[] args)
    {
        var path = args[0];
        var fileAsLines = Reader.ReadFile($"../../../{path}").Split("\n");
        var lexer = new Lexer();
        var tokens = lexer.Tokenize(fileAsLines);
        foreach (var token in tokens)
        {
            Console.WriteLine(token);
        }
    }
}