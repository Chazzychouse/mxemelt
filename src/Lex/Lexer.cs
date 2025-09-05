namespace Mxemelt.Lex;

public class Lexer
{
    private List<Token> _tokens = [];
    private const int _returnOffset = 5;
    
    public Lexer()
    {
    }
    
    public Token[] Tokenize(string[] file)
    {
        for (var i = 0; i < file.Length; i++)
        {
            var line = file[i];
            for (var j = 0; j < line.Length; j++)
            {
                var offset = AddToken(line, i, j);
                j += offset;
            }
        }
        
        return _tokens.ToArray();
    }

    private int AddInvalidToken(string line, int i, int j)
    {
        var word = ReadUntilWhitespace(line, j);
        AddToken(TokenType.Invalid, word, i, j);
        return word.Offset();
    }

    private int AddToken(string line, int i, int j)
    {
        return line[j] switch
        {
            'r' or 'R' => AddReturnOrInvalid(line, i, j),
            ' ' or '\n' or '\t' or '\r' => 0,
            '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => AddIntLiteralOrInvalid(line, i, j),
            _ => AddInvalidToken(line, i, j)
        };
    }

    private int AddReturnOrInvalid(string line, int i, int j)
    {
        var word = ReadUntilWhitespace(line, j);
        if (!IsReturn(word))
        {
            AddToken(TokenType.Invalid, word, i, j);
            return word.Offset();
        }
        AddToken(TokenType.Return, word, i, j);
        return _returnOffset;
    }

    private static bool IsReturn(string word)
    {
        return word.Length == 6 && word.StartsWith("return");
    }
    
    private static bool IsWhiteSpace(char c)
    {
        return 
              c is ' ' 
                or '\n' 
                or '\t' 
                or '\r';
    }
    
    private static bool IsNumeric(char c)
    {
        return c is '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9';
    }
    
    private static string ReadUntilWhitespace(string line, int startIndex)
    {
        if (line is null) throw new ArgumentNullException(nameof(line));
        if ((uint)startIndex >= (uint)line.Length) return string.Empty;

        int end = startIndex;
        while (end < line.Length && !IsWhiteSpace(line[end]))
            end++;

        return line.Substring(startIndex, end - startIndex);
    }

    
    private int AddIntLiteralOrInvalid(string line, int lineIndex, int startCharIndex)
    {
        var word = ReadUntilWhitespace(line, startCharIndex);
        int end = startCharIndex;
        var wordAsCharArray = word.ToCharArray();
        if (wordAsCharArray.Any(c => !IsNumeric(c)))
            return AddInvalidToken(line, lineIndex, startCharIndex);
        
        AddToken(TokenType.IntegerLiteral, word, lineIndex, startCharIndex);
        return word.Offset();
    }
    
    private void AddToken(TokenType type, string value, int line, int column)
    {
        _tokens.Add(new Token(type, value, line, column));
    }
}

public static class StringExtensions
{
    public static int Offset(this string s) => string.IsNullOrEmpty(s) ? -1 : s.Length - 1;
}