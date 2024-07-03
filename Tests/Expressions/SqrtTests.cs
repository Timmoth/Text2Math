using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class SqrtTests
{
    [Theory]
    [InlineData("sqrt 2", 2)]
    [InlineData("sqrt -3.1", -3.1)]
    [InlineData("sqrt (2)", 2)]
    [InlineData("sqrt (2*2)", 4)]
    [InlineData("sqrt e", Math.E)]
    [InlineData(" sqrt pi ", Math.PI)]
    public void Sqrt_Function(string expression, double value)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(Math.Sqrt(value));
    }
}