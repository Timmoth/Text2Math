using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class VariableTests
{
    [Theory]
    [InlineData("x^2", 4)]
    [InlineData("x ^ y", 8)]
    [InlineData("(x + x * x) / y", 2)]
    public void Variable_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate(("x", 2), ("y", 3));

        // Then
        actual.Should().Be(expected);
    }
}