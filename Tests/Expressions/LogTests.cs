using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class LogTests
{
    [Theory]
    [InlineData("log 2", 2)]
    [InlineData("log -3.1", -3.1)]
    [InlineData("log (2)", 2)]
    [InlineData("log (2*2)", 4)]
    [InlineData("log e", Math.E)]
    [InlineData(" log pi ", Math.PI)]
    public void Log_Function(string expression, double value)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(Math.Log(value));
    }
}