using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class ExponentTests
{
    [Theory]
    [InlineData("2^2", 4)]
    [InlineData("2 ^ -2", 0.25)]
    [InlineData(" -2 ^ 2 ", 4)]
    [InlineData(" 2 ^ (2-2) ", 1)]
    [InlineData(" 1.5 ^ 2.5 ", 2.7556759606310752)]
    public void Exponent_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}