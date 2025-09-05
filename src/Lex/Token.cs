namespace Mxemelt.Lex;

public record Token
{
    public TokenType Type { get; init; }
    public string Value { get; init; }
    public int Line { get; init; }
    public int Column { get; init; }

    public Token(TokenType type, string value, int line, int column)
    {
        Type = type;
        Value = value;
        Line = line + 1;
        Column = column + 1;
    }
    public override string ToString()
    {
        return $"{Type}({Value}) at {Line}:{Column}";
    }
}
