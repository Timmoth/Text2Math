using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class ModuloTests
{
    [Theory]
    [InlineData("1 % 1", 0)]
    [InlineData("1 % 2", 1)]
    [InlineData("3 % 2.5", 0.5)]
    public void Modulo_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}