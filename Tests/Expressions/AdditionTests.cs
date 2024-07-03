using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class AdditionTests
{
    [Theory]
    [InlineData("1 + 1", 2)]
    [InlineData("1 + -1", 0)]
    [InlineData(" -1 + -1 ", -2)]
    [InlineData("1+1", 2)]
    [InlineData("2+3", 5)]
    [InlineData("10+0.5", 10.5)]
    [InlineData("10+.5", 10.5)]
    public void Addition_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}