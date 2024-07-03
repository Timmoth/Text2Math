namespace Text2Math;

/// <summary>
///     Tokenize mathematical expression string
/// </summary>
public class Lexer
{
    private const string PiKeyword = "pi";
    private const string EulerKeyword = "e";
    private const string LogKeyWord = "log";
    private const string SqrtKeyword = "sqrt";
    private const string SinKeyword = "sin";
    private const string CosKeyword = "cos";
    private const string TanKeyword = "tan";

    /// <summary>
    ///     The input text to be tokenized.
    /// </summary>
    private readonly string _text;

    /// <summary>
    ///     Initializes a new instance of the Lexer class with the specified input text.
    /// </summary>
    /// <param name="text">The input text to be tokenized.</param>
    public Lexer(string text)
    {
        _text = text;
    }

    /// <summary>
    ///     The current position in the input text.
    /// </summary>
    public int Position { get; private set; }

    /// <summary>
    ///     The current position in the input text.
    /// </summary>
    public Token CurrentToken { get; private set; }

    /// <summary>
    ///     The characters of the input text.
    /// </summary>
    public ReadOnlySpan<char> Characters => _text.AsSpan();

    /// <summary>
    ///     The current character at the current position.
    /// </summary>
    public char CurrentChar => Characters[Position];

    /// <summary>
    ///     Maps a character token to its corresponding TokenType.
    /// </summary>
    /// <param name="token">The character token.</param>
    /// <returns>The corresponding TokenType.</returns>
    internal TokenType MapToken(char token)
    {
        return token switch
        {
            '+' => TokenType.Plus,
            '-' => TokenType.Minus,
            '*' => TokenType.Mul,
            '/' => TokenType.Div,
            '%' => TokenType.Mod,
            '^' => TokenType.Caret,
            '(' => TokenType.LParen,
            ')' => TokenType.RParen,
            _ => throw new Exception($"Unrecognized token: '{token}'")
        };
    }

    /// <summary>
    ///     Maps a keyword token to its corresponding TokenType.
    /// </summary>
    /// <param name="token">The keyword token.</param>
    /// <returns>The corresponding TokenType.</returns>
    internal TokenType MapKeyword(ReadOnlySpan<char> token)
    {
        if (token.SequenceEqual(LogKeyWord.AsSpan())) return TokenType.Log;

        if (token.SequenceEqual(PiKeyword.AsSpan())) return TokenType.Pi;

        if (token.SequenceEqual(EulerKeyword.AsSpan())) return TokenType.Euler;

        if (token.SequenceEqual(SqrtKeyword.AsSpan())) return TokenType.Sqrt;

        if (token.SequenceEqual(SinKeyword.AsSpan())) return TokenType.Sin;

        if (token.SequenceEqual(TanKeyword.AsSpan())) return TokenType.Tan;

        if (token.SequenceEqual(CosKeyword.AsSpan())) return TokenType.Cos;

        throw new Exception($"Unrecognized key word: '{token}'");
    }

    /// <summary>
    ///     Retrieves the next keyword token from the input text.
    /// </summary>
    /// <returns>The next keyword token.</returns>
    private Token GetKeywordToken()
    {
        var start = Position;
        while (Position < _text.Length && char.IsLetter(CurrentChar))
            // Advance until the end of the key word
            Advance();

        return new Token
        {
            Start = start,
            Length = Position - start,
            TokenType = MapKeyword(Characters.Slice(start, Position - start))
        };
    }

    /// <summary>
    ///     Advances the current position in the input text.
    /// </summary>
    private void Advance()
    {
        // Increment the input position by one
        Position++;
    }

    /// <summary>
    ///     Skips any whitespace characters in the input text.
    /// </summary>
    private void SkipWhiteSpace()
    {
        while (Position < _text.Length && CurrentChar == ' ')
            // Advance until current character is no longer white space
            Advance();
    }

    /// <summary>
    ///     Retrieves the next number token from the input text.
    /// </summary>
    /// <returns>The next number token.</returns>
    private Token GetNumber()
    {
        var start = Position;
        while (Position < _text.Length && (char.IsDigit(CurrentChar) || CurrentChar == '.'))
            // Advance until the end of the number
            Advance();

        return new Token
        {
            Start = start,
            Length = Position - start,
            TokenType = TokenType.Number
        };
    }

    /// <summary>
    ///     Retrieves the next token from the input text.
    /// </summary>
    /// <returns>The next token.</returns>
    public void NextToken()
    {
        if (Position >= _text.Length)
        {
            // End of file
            CurrentToken = new Token
            {
                Start = -1,
                Length = -1,
                TokenType = TokenType.Eof
            };
            return;
        }

        if (CurrentChar == ' ')
        {
            // Ignore all white space
            SkipWhiteSpace();
            if (Position >= _text.Length)
            {
                // End of file
                CurrentToken = new Token
                {
                    Start = -1,
                    Length = -1,
                    TokenType = TokenType.Eof
                };
                return;
            }
        }

        if (char.IsLetter(CurrentChar))
        {
            // Next token is a key word
            CurrentToken = GetKeywordToken();
            return;
        }

        if (char.IsDigit(CurrentChar) || CurrentChar == '.')
        {
            // Next token is a number
            CurrentToken = GetNumber();
            return;
        }

        // Next token must be a single character token
        var token = MapToken(CurrentChar);
        Advance();
        CurrentToken = new Token
        {
            Start = Position - 1,
            Length = 1,
            TokenType = token
        };
    }
}