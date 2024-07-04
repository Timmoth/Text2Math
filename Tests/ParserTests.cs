using FluentAssertions;
using Text2Math;

namespace Tests;

public class ParserTests
{
    [Theory]
    [InlineData("1 + 2", typeof(AddNode))]
    [InlineData("1 - 2", typeof(SubNode))]
    [InlineData("1 * 2", typeof(MulNode))]
    [InlineData("1 / 2", typeof(DivNode))]
    [InlineData("1 % 2", typeof(ModNode))]
    [InlineData("1 ^ 2", typeof(ExponentNode))]
    public void Expression_Returns_CorrectNodeType(string input, Type type)
    {
        // Given
        var lexer = new Lexer(input);
        lexer.NextToken();

        // When
        var actual = Parser.Expression(lexer);

        // Then
        actual.Should().BeOfType(type);
    }

    [Theory]
    [InlineData("1 * 2", typeof(MulNode))]
    [InlineData("1 / 2", typeof(DivNode))]
    [InlineData("1 % 2", typeof(ModNode))]
    [InlineData("1 ^ 2", typeof(ExponentNode))]
    [InlineData("+1.2", typeof(PlusNode))]
    [InlineData("-3", typeof(MinusNode))]
    [InlineData("3.5", typeof(NumberNode))]
    [InlineData("log 3.2", typeof(LogNode))]
    [InlineData("sin 12", typeof(SinNode))]
    [InlineData("cos 2", typeof(CosNode))]
    [InlineData("tan pi", typeof(TanNode))]
    [InlineData("sqrt 2", typeof(SqrtNode))]
    [InlineData("pi", typeof(PiNode))]
    [InlineData("e", typeof(EulerNode))]
    [InlineData("x", typeof(VariableNode))]
    [InlineData("(pi)", typeof(PiNode))]
    public void Term_Returns_CorrectNodeType(string input, Type type)
    {
        // Given
        var lexer = new Lexer(input);
        lexer.NextToken();

        // When
        var actual = Parser.Term(lexer);

        // Then
        actual.Should().BeOfType(type);
    }

    [Theory]
    [InlineData("+1.2", typeof(PlusNode))]
    [InlineData("-3", typeof(MinusNode))]
    [InlineData("3.5", typeof(NumberNode))]
    [InlineData("log 3.2", typeof(LogNode))]
    [InlineData("sin 12", typeof(SinNode))]
    [InlineData("cos 2", typeof(CosNode))]
    [InlineData("tan pi", typeof(TanNode))]
    [InlineData("sqrt 2", typeof(SqrtNode))]
    [InlineData("pi", typeof(PiNode))]
    [InlineData("e", typeof(EulerNode))]
    [InlineData("x", typeof(VariableNode))]
    [InlineData("(pi)", typeof(PiNode))]
    public void Factor_Returns_CorrectNodeType(string input, Type type)
    {
        // Given
        var lexer = new Lexer(input);
        lexer.NextToken();

        // When
        var actual = Parser.Factor(lexer);

        // Then
        actual.Should().BeOfType(type);
    }
}