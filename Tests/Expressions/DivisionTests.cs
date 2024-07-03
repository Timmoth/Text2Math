using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class DivisionTests
{
    [Theory]
    [InlineData("1 / 1", 1)]
    [InlineData("1 / -1", -1)]
    [InlineData(" 1 / 1 ", 1)]
    [InlineData("1/1", 1)]
    [InlineData("6/3", 2)]
    [InlineData("10/0.5", 20)]
    [InlineData("10/.5", 20)]
    public void Division_Function(string expression, double expected)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(expected);
    }
}