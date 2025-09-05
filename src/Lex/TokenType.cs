namespace Mxemelt.Lex;

public enum TokenType
{
    // Literals
    Identifier,
    IntegerLiteral,
    FloatLiteral,
    StringLiteral,
    BooleanLiteral,
    
    // Keywords
    If,
    Else,
    While,
    For,
    Function,
    Return,
    Var,
    Let,
    True,
    False,
    
    // Operators
    Plus,
    Minus,
    Multiply,
    Divide,
    Modulo,
    Assign,
    Equal,
    NotEqual,
    LessThan,
    LessThanEqual,
    GreaterThan,
    GreaterThanEqual,
    And,
    Or,
    Not,
    
    // Punctuation
    LeftParen,
    RightParen,
    LeftBrace,
    RightBrace,
    LeftBracket,
    RightBracket,
    Semicolon,
    Comma,
    Dot,
    Colon,
    
    // Special
    Newline,
    Whitespace,
    Comment,
    EndOfFile,
    Invalid
}