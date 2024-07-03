using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class MultiplicationTests
{
    [Theory]
    [InlineData("1 * 1", 1)]
    [InlineData("1 * -1", -1)]
    [InlineData(" 1 * 1 ", 1)]
    [InlineData("1*1", 1)]
    [InlineData("2*3", 6)]
    [InlineData("10*0.5", 5)]
    [InlineData("10*.5", 5)]
    public void Multiplication_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}