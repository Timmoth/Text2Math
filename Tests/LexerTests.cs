using FluentAssertions;
using Text2Math;

namespace Tests;

public class LexerTests
{
    [Theory]
    [InlineData("1", new[] { TokenType.Number, TokenType.Eof })]
    [InlineData(" 1 + 2 ", new[] { TokenType.Number, TokenType.Plus, TokenType.Number, TokenType.Eof })]
    [InlineData(" 1.23 - log3 ",
        new[] { TokenType.Number, TokenType.Minus, TokenType.Log, TokenType.Number, TokenType.Eof })]
    [InlineData("sqrt(e * pi) ",
        new[]
        {
            TokenType.Sqrt, TokenType.LParen, TokenType.Euler, TokenType.Mul, TokenType.Pi, TokenType.RParen,
            TokenType.Eof
        })]
    public void NextToken_Returns_Correct_TokenTypes(string expression, TokenType[] expected)
    {
        // Given
        var lexer = new Lexer(expression);
        var actual = new List<TokenType>();

        // When
        lexer.NextToken();
        actual.Add(lexer.CurrentToken.TokenType);
        while (lexer.CurrentToken.TokenType != TokenType.Eof)
        {
            lexer.NextToken();
            actual.Add(lexer.CurrentToken.TokenType);
        }

        // Then
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void NextToken_Returns_Correct_TokenSequence()
    {
        // Given
        var lexer = new Lexer("1.2 log * ");
        var expected = new List<Token>
        {
            new(TokenType.Number, 0, 3),
            new(TokenType.Log, 4, 3),
            new(TokenType.Mul, 8, 1),
            new(TokenType.Eof, -1, -1)
        };
        var actual = new List<Token>();

        // When
        lexer.NextToken();
        actual.Add(lexer.CurrentToken);
        while (lexer.CurrentToken.TokenType != TokenType.Eof)
        {
            lexer.NextToken();
            actual.Add(lexer.CurrentToken);
        }

        // Then
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData('+', TokenType.Plus)]
    [InlineData('-', TokenType.Minus)]
    [InlineData('*', TokenType.Mul)]
    [InlineData('/', TokenType.Div)]
    [InlineData('^', TokenType.Caret)]
    [InlineData('%', TokenType.Mod)]
    [InlineData('(', TokenType.LParen)]
    [InlineData(')', TokenType.RParen)]
    public void MapToken_Returns_Correct_Token(char input, TokenType expected)
    {
        // Given
        var lexer = new Lexer("");

        // When
        var actual = lexer.MapToken(input);

        // Then
        actual.Should().Be(expected);
    }

    [Fact]
    public void MapToken_Throws_Exception()
    {
        // Given
        var lexer = new Lexer("");

        // When
        // Then
        var exception = Assert.Throws<Exception>(() => lexer.MapToken('.'));
        exception.Message.Should().Be("Unrecognized token: '.'");
    }

    [Theory]
    [InlineData("pi", TokenType.Pi)]
    [InlineData("e", TokenType.Euler)]
    [InlineData("log", TokenType.Log)]
    [InlineData("sqrt", TokenType.Sqrt)]
    [InlineData("sin", TokenType.Sin)]
    [InlineData("cos", TokenType.Cos)]
    [InlineData("tan", TokenType.Tan)]
    public void MapKeyword_Returns_Correct_Token(string input, TokenType expected)
    {
        // Given
        var lexer = new Lexer("");

        // When
        var actual = lexer.MapKeyword(input);

        // Then
        actual.Should().Be(expected);
    }

    [Fact]
    public void MapKeyword_Throws_Exception()
    {
        // Given
        var lexer = new Lexer("");

        // When
        // Then
        var exception = Assert.Throws<Exception>(() => lexer.MapKeyword("invalid"));
        exception.Message.Should().Be("Unrecognized key word: 'invalid'");
    }
}