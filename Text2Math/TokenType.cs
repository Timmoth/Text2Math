namespace Text2Math;

/// <summary>
///     Represents the type of a token
/// </summary>
public enum TokenType
{
#pragma warning disable CS1591
    Number,
    Plus,
    Minus,
    Mul,
    Div,
    LParen,
    RParen,
    Caret,
    Mod,
    Log,
    Sqrt,
    Sin,
    Cos,
    Tan,
    Pi,
    Euler,
    Variable,
    Eof
#pragma warning restore CS1591
}