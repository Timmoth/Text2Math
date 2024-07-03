namespace Text2Math;

/// <summary>
///     Static methods for parsing a mathematical expression
/// </summary>
public static class Parser
{
    /// <summary>
    ///     Parses a mathematical expression.
    /// </summary>
    /// <returns>The parsed AST node representing the expression.</returns>
    public static AstNode Parse(this string input)
    {
        var lexer = new Lexer(input);
        lexer.NextToken();
        return Expression(lexer);
    }

    /// <summary>
    ///     Parses a mathematical expression.
    /// </summary>
    /// <returns>The parsed AST node representing the expression.</returns>
    internal static AstNode Expression(Lexer lexer)
    {
        // expression   : term ((plus | minus ) term)*
        // term         : factor((mul | div | caret | mod) factor)*
        // factor       : number | log | sin | cos | tan | sqrt | plus | minus | pi | e | lparen expression rparen

        var node = Term(lexer);
        while (lexer.CurrentToken.TokenType is
               TokenType.Plus or TokenType.Minus)
            switch (lexer.CurrentToken.TokenType)
            {
                case TokenType.Plus:
                    lexer.NextToken();
                    node = new AddNode(node, Term(lexer));
                    break;
                case TokenType.Minus:
                    lexer.NextToken();
                    node = new SubNode(node, Term(lexer));
                    break;
            }

        return node;
    }

    /// <summary>
    ///     Parses a term.
    /// </summary>
    /// <returns>The parsed AST node representing the term.</returns>
    internal static AstNode Term(Lexer lexer)
    {
        // expression   : term ((plus | minus ) term)*
        // term         : factor((mul | div | caret | mod) factor)*
        // factor       : number | log | sin | cos | tan | sqrt | plus | minus | pi | e | lparen expression rparen

        var node = Factor(lexer);

        while (lexer.CurrentToken.TokenType is TokenType.Mul or TokenType.Div or TokenType.Caret or TokenType.Mod)
        {
            var token = lexer.CurrentToken;
            switch (token.TokenType)
            {
                case TokenType.Mul:
                    lexer.NextToken();
                    node = new MulNode(node, Factor(lexer));
                    break;
                case TokenType.Div:
                    lexer.NextToken();
                    node = new DivNode(node, Factor(lexer));
                    break;
                case TokenType.Caret:
                    lexer.NextToken();
                    node = new ExponentNode(node, Factor(lexer));
                    break;
                case TokenType.Mod:
                    lexer.NextToken();
                    node = new ModNode(node, Factor(lexer));
                    break;
            }
        }

        return node;
    }

    /// <summary>
    ///     Parses a factor.
    /// </summary>
    /// <returns>The parsed AST node representing the factor.</returns>
    internal static AstNode Factor(Lexer lexer)
    {
        // expression   : term ((plus | minus ) term)*
        // term         : factor((mul | div | caret | mod) factor)*
        // factor       : number | log | sin | cos | tan | sqrt | plus | minus | pi | e | lparen expression rparen

        var token = lexer.CurrentToken;
        switch (token.TokenType)
        {
            case TokenType.Plus:
                lexer.NextToken();
                return new PlusNode(Factor(lexer));
            case TokenType.Minus:
                lexer.NextToken();
                return new MinusNode(Factor(lexer));
            case TokenType.Log:
                lexer.NextToken();
                return new LogNode(Factor(lexer));
            case TokenType.Sin:
                lexer.NextToken();
                return new SinNode(Factor(lexer));
            case TokenType.Tan:
                lexer.NextToken();
                return new TanNode(Factor(lexer));
            case TokenType.Cos:
                lexer.NextToken();
                return new CosNode(Factor(lexer));
            case TokenType.Sqrt:
                lexer.NextToken();
                return new SqrtNode(Factor(lexer));
            case TokenType.Number:
                lexer.NextToken();
                return new NumberNode(double.Parse(lexer.Characters.Slice(token.Start, token.Length)));
            case TokenType.Pi:
                lexer.NextToken();
                return new PiNode();
            case TokenType.Euler:
                lexer.NextToken();
                return new EulerNode();
            case TokenType.LParen:
            {
                lexer.NextToken();
                var node = Expression(lexer);
                lexer.NextToken();
                return node;
            }
            default:
                throw new Exception($"Invalid factor token: '{token.TokenType}'");
        }
    }

    /// <summary>
    ///     Parses and evaluates the given mathematical expression
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static double Evaluate(this string input)
    {
        return Parse(input).Evaluate();
    }
}