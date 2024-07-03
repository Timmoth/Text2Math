using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class ConstantTests
{
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    [InlineData("6", 6)]
    [InlineData("7", 7)]
    [InlineData("8", 8)]
    [InlineData("9", 9)]
    [InlineData("10", 10)]
    [InlineData("1.2", 1.2)]
    [InlineData("0.3", 0.3)]
    [InlineData("0.45", 0.45)]
    [InlineData(".45", .45)]
    [InlineData(" 1", 1)]
    [InlineData(" 1 ", 1)]
    [InlineData("1 ", 1)]
    [InlineData("e", Math.E)]
    [InlineData("pi", Math.PI)]
    public void Constants(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("-0", 0)]
    [InlineData("+1", 1)]
    [InlineData("-2", -2)]
    [InlineData("++1", 1)]
    [InlineData("--1 ", 1)]
    [InlineData("-+-+-+1", -1)]
    [InlineData("-e", -Math.E)]
    [InlineData("-pi", -Math.PI)]
    public void SignedConstant(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}