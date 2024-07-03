using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class SubtractionTests
{
    [Theory]
    [InlineData("1 - 1", 0)]
    [InlineData("1 - -1", 2)]
    [InlineData(" -1 - -1 ", 0)]
    [InlineData("3-1", 2)]
    [InlineData("2-3", -1)]
    [InlineData("10-0.5", 9.5)]
    [InlineData("10-.5", 9.5)]
    public void Subtraction_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}