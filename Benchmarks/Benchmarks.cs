using BenchmarkDotNet.Attributes;
using Text2Math;

namespace Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private const string Expression = "sqrt(.4 ^ 2) - (4 * tan 5 - cos(-2)) / sin(e^4) + log(pi - 1.2)";

    [Benchmark]
    public void Tokenization()
    {
        var lexer = new Lexer(Expression);
        lexer.NextToken();
        while (lexer.CurrentToken.TokenType != TokenType.Eof) lexer.NextToken();
    }

    [Benchmark]
    public void Parsing()
    {
        var rootNode = Expression.Parse();
    }

    [Benchmark]
    public void Evaluation()
    {
        var result = Expression.Evaluate();
    }
}