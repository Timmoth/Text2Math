using FluentAssertions;
using Text2Math;

namespace Tests.Expressions;

public class TrigTests
{
    [Theory]
    [InlineData("sin 2", 2)]
    [InlineData("sin -3.1", -3.1)]
    [InlineData("sin (2)", 2)]
    [InlineData("sin (2*2)", 4)]
    [InlineData("sin e", Math.E)]
    [InlineData(" sin pi ", Math.PI)]
    public void Sin_Function(string expression, double value)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(Math.Sin(value));
    }

    [Theory]
    [InlineData("cos 2", 2)]
    [InlineData("cos -3.1", -3.1)]
    [InlineData("cos (2)", 2)]
    [InlineData("cos (2*2)", 4)]
    [InlineData("cos e", Math.E)]
    [InlineData(" cos pi ", Math.PI)]
    public void Cos_Function(string expression, double value)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(Math.Cos(value));
    }

    [Theory]
    [InlineData("tan 2", 2)]
    [InlineData("tan -3.1", -3.1)]
    [InlineData("tan (2)", 2)]
    [InlineData("tan (2*2)", 4)]
    [InlineData("tan e", Math.E)]
    [InlineData(" tan pi ", Math.PI)]
    public void Tan_Function(string expression, double value)
    {
        // When
        var actual = expression.Evaluate();

        // Then
        actual.Should().Be(Math.Tan(value));
    }
}