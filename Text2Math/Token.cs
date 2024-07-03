namespace Text2Math;

/// <summary>
///     Represents a token
/// </summary>
/// <param name="TokenType"></param>
/// <param name="Start"></param>
/// <param name="Length"></param>
public readonly record struct Token(TokenType TokenType, int Start, int Length);