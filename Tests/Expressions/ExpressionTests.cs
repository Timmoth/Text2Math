using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class ExpressionTests
{
    [Theory]
    [InlineData("2 * 2 - 1", 3)]
    [InlineData("2 * (2 - 1)", 2)]
    [InlineData("-2 * (2 - 1)", -2)]
    [InlineData("-2 / -(2 * 2)", 0.5)]
    [InlineData("2*sin(pi/2-1)+pi", 4.222197265326073)]
    [InlineData("sqrt(4) % 2 ^ 2", 0)]
    [InlineData("sqrt(3^2 + (sin(3) / cos(3))^2) + log(e^3)", 6.003384676817545)]
    public void Expression(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}